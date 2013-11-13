using UnityEngine;
using System.Collections;

public class BehaviorCoin : MonoBehaviour {

	private float speedRot = 120.0f;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Bringing the coins down to the ground
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, 10))
		{
            float distanceToGround = hit.distance;
			//distanceToGround = (float) Mathf.Clamp(distanceToGround, -0.02f, 0.02f);
			this.transform.Translate(-Vector3.up * distanceToGround);
		}
		
		//rotation
		this.transform.Rotate(Vector3.up * speedRot * Time.deltaTime);

	}
}
