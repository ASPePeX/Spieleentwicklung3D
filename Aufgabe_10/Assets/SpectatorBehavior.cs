using UnityEngine;
using System.Collections;

public class SpectatorBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Bringing spectators down to the ground
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, 10))
		{
            float distanceToGround = hit.distance;
			this.transform.Translate(-Vector3.up * distanceToGround);
			//Debug.Log("Spec pos corr");
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Toooooor()
	{
		//Debug.Log(this.gameObject.name + ": " + bla);
		animation.Play("Jump");
	}
	
	void AnimationEnded(string _name)
	{

	}

}
