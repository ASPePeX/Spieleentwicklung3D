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
			this.transform.Translate(-Vector3.up * distanceToGround);
			Debug.Log("Coin pos corr");
		}
		
		//rotation
		this.transform.Rotate(Vector3.up * speedRot * Time.deltaTime);

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
        Destroy(this.gameObject);
    }
}
