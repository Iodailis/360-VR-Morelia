using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class mapButton : MonoBehaviour {


	public event Action<mapButton> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.


	//[SerializeField] private string m_SceneToLoad;                      // The name of the scene to load.
	//[SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
	[SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
	[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
	//[SerializeField] private GameObject m_Scene;
	//private GameObject m_Camera;
	[SerializeField] private VREyeRaycaster ray; 
	[SerializeField] private GameObject eyes; 
	[SerializeField] private Animator menu; 
	[SerializeField] private Animator mapaInterfaz; 
	[SerializeField] private GameObject mapa; 
	[SerializeField] private SphereCollider exitCol; 


	private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.
	//int temp = 0;

	private void OnEnable ()
	{
		Debug.Log (false);
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
		// If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.

		if (m_GazeOver) {
			ray.setRayLength(15);
			exitCol.enabled = true;
			menu.Play ("scaleDown");
			menu.SetBool ("scaleUp", false);
			menu.SetBool ("scaleDown", true);

			mapa.transform.localEulerAngles = new Vector3 (0, eyes.transform.localEulerAngles.y, 0);
			mapaInterfaz.Play ("mapaShow");
			m_SelectionRadial.Hide();
			
		}
			

	}
		


	public bool isLooking(){
		return m_GazeOver;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
