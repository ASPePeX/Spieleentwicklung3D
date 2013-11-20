using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Boom(Vector3 camRot) 
	{
		this.rigidbody.velocity = Vector3.zero;
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.Euler(Vector3.zero);
		transform.rotation = Quaternion.Euler(camRot);
		rigidbody.AddForce(Vector3.forward * 50, ForceMode.VelocityChange);
		rigidbody.useGravity = true;
	}
}
  