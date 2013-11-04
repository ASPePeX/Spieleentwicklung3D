using UnityEngine;
using System.Collections;

public class AnimationHandling : MonoBehaviour {
	
	private GameObject dollyGo;
	private CameraTracking2 dolly;

	// Use this for initialization
	void Start () {
		dollyGo = GameObject.Find("/Dolly");
		dolly = (CameraTracking2) dollyGo.GetComponent(typeof(CameraTracking2));
	}
	
	// Update is called once per frame
	void Update () {
	
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
