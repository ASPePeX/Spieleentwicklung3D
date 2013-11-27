using UnityEngine;
using System.Collections;

public class Reciever : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void GetMessage(string bla)
	{
		Debug.Log(this.gameObject.name + ": " + bla);
	}
	
}
