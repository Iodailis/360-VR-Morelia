using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

namespace VRStandardAssets.exit
{
	// This script is for loading scenes from the main menu.
	// Each 'button' will be a rendering showing the scene
	// that will be loaded and use the SelectionRadial.
	public class exit : MonoBehaviour
	{
		public event Action<exit> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.


		//[SerializeField] private string m_SceneToLoad;                      // The name of the scene to load.
		//[SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
		[SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
		[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
		[SerializeField] private Animator mapaInterfaz;
		//[SerializeField] private GameObject m_Scene;
		//private GameObject m_Camera;


		[SerializeField] private GameObject blackBG; 
		[SerializeField] private VREyeRaycaster ray; 
		[SerializeField] private GameObject mapa; 

		[SerializeField] private SphereCollider exitCol; 

		private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.

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
			ray.setRayLength(100);
			/*Animator anim = blackBG.GetComponent<Animator>();
			anim.SetBool ("isFadingIn", false);
			anim.SetBool ("isFadingOut", true);
			mapa temp = mapa.GetComponentInChildren<mapa> ();
			temp.StartCoroutine ("hideMap");
			exitCol.enabled = false;*/

			mapaInterfaz.Play ("fadeOut");
		}


	}
}