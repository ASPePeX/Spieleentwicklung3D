using UnityEngine;
using System.Collections;

public class MessageRelay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void RelayMessage(string bla)
	{
		BroadcastMessage(bla);
	}

}
