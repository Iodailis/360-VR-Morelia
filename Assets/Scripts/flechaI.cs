using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class flechaI : MonoBehaviour {

	public event Action<flechaI> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.


	//[SerializeField] private string m_SceneToLoad;                      // The name of the scene to load.
	[SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
	[SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
	[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
	[SerializeField] private VREyeRaycaster ray; 
	private GameObject m_Camera;
	[SerializeField] private gcScript GameController;



	private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.
	int temp = 0;

	private void OnEnable ()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
		m_Camera = GameObject.Find ("CameraHolder");
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
		if(m_GazeOver)
			StartCoroutine (ActivateButton());
	}


	private IEnumerator ActivateButton()
	{
		// If the camera is already fading, ignore.
		if (m_CameraFade.IsFading)
			yield break;
		// If anything is subscribed to the OnButtonSelected event, call it.
		if (OnButtonSelected != null)
			OnButtonSelected(this);

		// Wait for the camera to fade out.
		yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));
		// Load the level.
		//SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
		int posNum = GameController.pos;

		posNum--;
		if (posNum < 1)
			posNum = 12;
		Vector3 pos = GameObject.FindGameObjectWithTag(posNum.ToString()).transform.position;
		m_Camera.transform.position = pos;
		yield return StartCoroutine(m_CameraFade.BeginFadeIn(true));
		yield return new WaitForSeconds (0);
	}

	public bool isLooking(){
		return m_GazeOver;
	}
}
