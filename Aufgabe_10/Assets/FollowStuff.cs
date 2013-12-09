using UnityEngine;
using System.Collections;

public class FollowStuff : CharacterStuff {
	
	private Transform player;
	private float rotSpeed = 0.8f;
	private float walkSpeed = 0.013f;
	
	// Use this for initialization
	new void Start ()
	{
		player = GameObject.Find("root/Character").transform;
	}
	
	// Update is called once per frame
	new void Update ()
	{
		base.Update();
		
		
		Quaternion targetRotation = Quaternion.LookRotation (player.position - this.transform.position);
  		float rot = Mathf.Min (rotSpeed * Time.deltaTime, 1);
  		this.transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, rot);
				
		if (Vector3.Distance(this.transform.position, player.position) > 2)
		{
			this.transform.Translate(Vector3.forward * walkSpeed);
			this.animation.CrossFade("Walk");
		}
			
	}
}
