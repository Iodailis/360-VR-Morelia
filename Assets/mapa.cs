using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class mapa : MonoBehaviour {


	public event Action<mapa> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.


	[SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
	[SerializeField] private VREyeRaycaster ray; 
	[SerializeField] private GameObject mapInterface; 
	[SerializeField] private SphereCollider[] botonMapa;
	[SerializeField] private SphereCollider botonMapa1;
	[SerializeField] private SphereCollider botonMapa2;
	[SerializeField] private SphereCollider botonMapa3;
	[SerializeField] private SphereCollider botonMapa4;
	[SerializeField] private SphereCollider botonMapa5;
	[SerializeField] private SphereCollider botonMapa6;
	[SerializeField] private SphereCollider botonMapa7;
	[SerializeField] private SphereCollider botonMapa8; 


	private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


	private void OnEnable ()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
	}


	private void OnDisable ()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;

	}


	private void HandleOver()
	{

		ray.setRayLength(15);


		m_GazeOver = true;
	}

	private void HandleOut()
	{


		ray.setRayLength(18);
		
		m_GazeOver = false;
	}

	private void HandleSelectionComplete()
	{
		// If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.


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

