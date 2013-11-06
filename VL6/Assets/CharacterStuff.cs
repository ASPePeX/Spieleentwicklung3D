using UnityEngine;
using System.Collections;

public class CharacterStuff : MonoBehaviour {
	
	private GameObject dollyGo;
	private CameraTracking2 dolly;

	// Use this for initialization
	void Start () {
		dollyGo = GameObject.Find("/Dolly");
		dolly = (CameraTracking2) dollyGo.GetComponent(typeof(CameraTracking2));
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
		{
            float distanceToGround = hit.distance;
			distanceToGround = (float) Mathf.Clamp(0.5f + distanceToGround, -0.05f, 0.05f);
			this.transform.Translate(-Vector3.up * distanceToGround);
			
			Debug.Log("Moved " + this.gameObject.name + " down to the ground. (Down by " + distanceToGround + ")");
		}
	}

	void AnimationEnded(string _name)
	{
		Debug.Log("Animation Ended: " +_name);
		animation.Play("Idle");
		
		if (_name == "Jump")
		{
			dolly.jumpEnd();
		}
		if (_name == "Idle")
		{
			dolly.idleEnd();
		}
	}
}
