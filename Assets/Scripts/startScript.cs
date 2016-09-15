using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class startScript : MonoBehaviour {


	public event Action<startScript> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.


	//[SerializeField] private string m_SceneToLoad;                      // The name of the scene to load.
	//[SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
	[SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
	[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
	//[SerializeField] private GameObject m_Scene;
	//private GameObject m_Camera;

	[SerializeField] private Animator anim; 
	[SerializeField] private GameObject menuitem1; 
	[SerializeField] private GameObject menuitem2; 
	[SerializeField] private GameObject menuitem3; 


	private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.
	//int temp = 0;

	private void OnEnable ()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
		//m_Camera = GameObject.Find ("CameraHolder");
	}


	private void OnDisable ()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
	}


	private void HandleOver()
	{
		// When the user looks at the rendering of the scene, show the radial.
		m_SelectionRadial.Show();

		StartCoroutine ("showMenuItems");

		m_GazeOver = true;
	}

	private void HandleOut()
	{
		// When the user looks away from the rendering of the scene, hide the radial.
		m_SelectionRadial.Hide();

		m_GazeOver = false;
	}

	private void HandleSelectionComplete()
	{
		if(!anim.GetCurrentAnimatorStateInfo (0).IsName ("pruebaShow"))
			anim.Play ("pruebaShow");
	}


	private IEnumerator showMenuItems()
	{
		
		if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("scaleDown")) {
			anim.Play ("scaleUp");
		}
		anim.SetBool ("scaleUp", true);
		anim.SetBool ("scaleDown", false);


		yield break;
	}


	public bool isLooking(){
		return m_GazeOver;
	}
}
