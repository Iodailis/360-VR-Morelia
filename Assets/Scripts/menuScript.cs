using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class menuScript : MonoBehaviour {

	public event Action<menuScript> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.


	//[SerializeField] private string m_SceneToLoad;                      // The name of the scene to load.
	//[SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
	//[SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
	[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
	//[SerializeField] private GameObject m_Scene;
	//private GameObject m_Camera;
	[SerializeField] private Animator anim; 
	[SerializeField] private GameObject menuitem1; 
	[SerializeField] private GameObject menuitem2; 
	[SerializeField] private GameObject menuitem3; 
	[SerializeField] private GameObject menuitem4; 


	private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.
	//int temp = 0;

	private void OnEnable ()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		//m_Camera = GameObject.Find ("CameraHolder");
	}


	private void OnDisable ()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
	}


	private void HandleOver()
	{
		// When the user looks at the rendering of the scene, show the radial.
		//m_SelectionRadial.Show();


		m_GazeOver = true;
	}

	private void HandleOut()
	{
		derechaI mapa = menuitem3.GetComponent<derechaI> ();
		bool bool1 = mapa.isLooking ();
		startScript start = menuitem4.GetComponent<startScript> ();
		bool bool2 = start.isLooking ();
		mapButton close = menuitem2.GetComponent<mapButton> ();
		bool bool3 = close.isLooking ();
		flechaI info = menuitem1.GetComponent<flechaI> ();
		bool bool4 = info.isLooking ();
		if (!bool1 && !bool2 && !bool3 && !bool4) {
			if (!anim.GetCurrentAnimatorStateInfo (0).IsName ("scaleUp"))
				anim.Play ("scaleDown");
			anim.SetBool ("scaleUp", false);
			anim.SetBool ("scaleDown", true);
		}else	m_GazeOver = false;
	}

	private void HandleSelectionComplete()
	{
		// If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.

	}




	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
