using UnityEngine;
using System.Collections;

public class Sender : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			SendMessage("GetMessage", "SendMessage");
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			BroadcastMessage("GetMessage", "BroadcastMessage");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			SendMessageUpwards("GetMessage", "SendMessageUpwards");
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			SendMessageUpwards("RelayMessage", "GlobalRelay");
		}
		
		
	}
}
