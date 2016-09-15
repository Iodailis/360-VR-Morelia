using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class Info : MonoBehaviour {
	public event Action<Info> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.

	[SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
	[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.

	[SerializeField] private GameObject self;
	private bool isSpinning = true;


	private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


	private void OnEnable ()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
	}


	private void OnDisable ()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
	}


	private void HandleOver()
	{
		isSpinning = false;
	}


	private void HandleOut()
	{
		isSpinning = true;
	}


	private void HandleSelectionComplete()
	{
		// If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
		if(m_GazeOver)
			StartCoroutine (ActivateButton());
	}


	private IEnumerator ActivateButton()
	{
		yield return new WaitForSeconds(1);
	}

	void Update()
	{
		if (isSpinning) {

			transform.Rotate (Vector3.up * -Time.deltaTime*100, Space.Self);
		}
	}
}
