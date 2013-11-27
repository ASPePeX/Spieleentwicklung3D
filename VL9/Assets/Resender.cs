using UnityEngine;
using System.Collections;

public class Resender : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void RelayMessage(string bla)
	{
		Debug.Log(this.gameObject.name + ": " + bla);
		BroadcastMessage("GetMessage", this.gameObject.name + ": GlobalMessage");
	}

}
