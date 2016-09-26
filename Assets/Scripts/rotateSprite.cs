using UnityEngine;
using System.Collections;


public class rotateSprite : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



		//transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x));
		Quaternion rot = Quaternion.LookRotation(transform.position - target.position, Vector3.forward );
		transform.rotation = rot;  
		transform.eulerAngles = new Vector3(0-90,transform.eulerAngles.y-90, 0);

	}
}
