using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {
	
	private bool move = false;
	private bool rotated = false;
	private int nextAnimation = 0;
	private int animQueue = 0;
	
	
		
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey("1"))
		{
			animQueue = 1;
		}
		else if (Input.GetKey("2"))
		{
			animQueue = 2;
		}
		else if (Input.GetKey("3"))
		{
			animQueue = 3;
		}
		
		// Movement
		if (move)
			transform.Translate(Vector3.forward * Time.deltaTime);
	}
	
	void RandMove () {
		
		if (transform.position.z > 20 && !rotated)
		{
			transform.Rotate(0,180,0);
			rotated = true;
		}
		else if (transform.position.z < 0 && rotated)
		{
			transform.Rotate(0,-180,0);
			rotated = false;
		}
		
		if (animQueue > 0)
		{
			nextAnimation = animQueue;
			Debug.Log("User picked animation: " + nextAnimation);
		}
		else
		{
			nextAnimation = Random.Range(1,4);
			Debug.Log("Random animation: " + nextAnimation);
		}

		
		animation.Stop();
		animation.Rewind();
		switch (nextAnimation) {
		case 1:
			animation.Play("Idle");
			move = false;
			break;
		case 2:
			animation.Play("Walk");
			move = true;
			break;
		case 3:
			animation.Play("Jump");
			break;
		case 4:
			Debug.Log("WTF");
			animation.Play("Walk");
			move = true;
			break;
		}
		animQueue = 0;
	}
}
