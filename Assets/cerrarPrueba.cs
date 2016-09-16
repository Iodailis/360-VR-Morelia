using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;
public class cerrarPrueba : MonoBehaviour {

	//[SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
	[SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
	[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
	[SerializeField] private Animator anim;
	//[SerializeField] private GameObject m_Scene;
	//private GameObject m_Camera;




	private bool m_GazeOver;   

	private void OnEnable ()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		//m_InteractiveItem.OnClick += Click;
		m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
	}


	private void OnDisable ()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		//m_InteractiveItem.OnClick -= Click;
		m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
	}

	private void HandleOver()
	{

		Debug.Log (234);
		// When the user looks at the rendering of the scene, show the radial.
		m_SelectionRadial.Show();

		m_GazeOver = true;
	}


	private void HandleOut()
	{
		Debug.Log (234);
		// When the user looks away from the rendering of the scene, hide the radial.
		m_SelectionRadial.Hide();

		m_GazeOver = false;
	}



	private void HandleSelectionComplete()
	{


		anim.Play ("pruebaHide");
	}
}
