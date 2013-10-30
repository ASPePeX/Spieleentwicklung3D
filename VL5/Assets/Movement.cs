using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public float walkspeed = 0.5f;
	public float turnspeed = 0.5f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetKeys();
	}
	
	void GetKeys () {
		float walk = 0.0f;
		float turn = 0.0f;
		bool jump = false;
		
		walk = Input.GetAxis("Vertical") * walkspeed;
		turn = Input.GetAxis("Horizontal") * turnspeed;

		if (Input.GetKey("space"))
			{
				jump = true;
			}
		
		Move(walk, turn, jump);
	}
	
	void Move (float _walk, float _turn, bool _jump) {
		Debug.Log(Anim.Idle + " " + _walk + " " + _turn + " " + _jump);
	}
	
	void AnimationPlay (int _anim) {
		
	}
	
	string AnimationCheck () {
		return "bla";
	}
	
	enum Anim {
		Idle,
		Walk,
		Jump
	}
	
}
