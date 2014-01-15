using UnityEngine;
using System.Collections;

public class CharacterStuff : MonoBehaviour {
	
	protected GameObject dollyGo;
	protected CameraTracking2 dolly;
	public AudioClip clip;

	// Use this for initialization
	public void Start () {
		dollyGo = GameObject.Find("Dolly");
		dolly = (CameraTracking2) dollyGo.GetComponent(typeof(CameraTracking2));
	}
	
	// Update is called once per frame
	public void Update () {
        RaycastHit hit;
		if (Physics.Raycast(transform.position, Vector3.up, out hit))
		{
            float distanceToGround = hit.distance;
			distanceToGround = (float) Mathf.Clamp(0.2f + distanceToGround, -0.02f, 0.02f);
			this.transform.Translate(Vector3.up * distanceToGround);
			
			//Debug.Log("Moved " + this.gameObject.name + " up to the ground. (Down by " + distanceToGround + ")");
		}
		if (Physics.Raycast(transform.position, -Vector3.up, out hit))
		{
            float distanceToGround = hit.distance;
			distanceToGround = (float) Mathf.Clamp(0.2f + distanceToGround, -0.02f, 0.02f);
			this.transform.Translate(-Vector3.up * distanceToGround);
			
			//Debug.Log("Moved " + this.gameObject.name + " down to the ground. (Down by " + distanceToGround + ")");
		}

	}

	public void AnimationEnded(string _name)
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
	
	public void StepSound()
	{
		AudioSource.PlayClipAtPoint(clip, this.transform.position);
	}
}
