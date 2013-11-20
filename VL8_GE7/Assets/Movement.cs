using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	private Vector3 camRot;
	private Vector3 camMov;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		camRot.y = Input.GetAxis("Horizontal") + camRot.y;
		camRot.x = Input.GetAxis("Vertical") * -1 + camRot.x;
		
		this.transform.rotation = Quaternion.Euler(camRot);
		
		if (Input.GetKey(KeyCode.Space))
		{
			
			GameObject.Find("Ball").SendMessage("Boom",camRot);
		}
	}
}
