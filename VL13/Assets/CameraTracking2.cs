﻿using UnityEngine;
using System.Collections;

public class CameraTracking2 : MonoBehaviour {
	
	public float distance = 4;
	public float mouseSense = 2.5f;
	public float mouseScrollSense = 1.0f;
	
	private int vRotMax = 60;
	private int vRotMin = -20;
	
	private float distMax = 10.0f;
	private float distMin = 1.2f;
	
	//private Transform target;
	private Transform cam;
	private Transform dolly;
	private Transform target;
	private Transform ball;
	private GameObject character;
	public Transform pfCoin;
	private GameObject lighty;
	
	private float hRot;
	private float vRot;
	
	private float walkspeed = 0.015f;
	private float turnspeed = 1.5f;
	
	private float walk;
	private float turn;
	private bool jumping;
	private bool idling;
	
	private float hSliderValue = 5f;
	private bool gameRunning = false;
	private float lightStart = 0.0f;
	private float lightEnd = 0.5f;
	private float lightInc = 0.003f;
	private float lightVal;
	
	// Use this for initialization
	void Start () {
		character = GameObject.Find("/root/Character");
		target = character.transform.Find("Hip/Torso/Neck/MeshHead");
		//target = GameObject.Find("MeshHead").transform;
		cam = transform.FindChild("Camera");
		dolly = this.transform;
		ball = GameObject.Find("root/Ball").transform;
		lighty = GameObject.Find("root/Lighty");
		lightVal = lightStart;
	}
	
	// Update is called once per frame
	void Update () {
		// Do raycast on click and get the new character
				lighty.light.intensity = lightVal;
		Debug.Log (lightVal);

		
		
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit)
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.tag == "Player")
				{
					character = hitInfo.transform.gameObject;
					target = character.transform.Find("Hip/Torso/Neck/MeshHead");
				}
			}
		} 
		if (gameRunning)
		{
			if (lightVal < lightEnd)
				lightVal = lightVal + lightInc;
			// Do the character movement
			walk = Input.GetAxis("Vertical") * walkspeed;
			turn = Input.GetAxis("Horizontal") * turnspeed;
			
			character.transform.Translate(Vector3.forward * walk);
			character.transform.Rotate(Vector3.up * turn);
			
			if (Input.GetKey(KeyCode.Space))
			{
				jumping = true;
			}
			// Trigger Animations
			
			//startwalking
			if (walk != 0 && !jumping)
			{
				character.animation.CrossFade("Walk");
				idling = false;
			}
			else if (walk == 0 && !jumping && !idling)
			{
				character.animation.CrossFade("Idle");
				idling = true;
			}
			else if (jumping)
			{	
				character.animation.CrossFade("Jump");
				idling = false;
			}
			if (Input.GetKey(KeyCode.Return))
			{
				Vector3 kickdir = ball.position - character.transform.position;
				if (kickdir.magnitude < 2)
				{
					ball.rigidbody.AddForce(kickdir.normalized * 5, ForceMode.VelocityChange);
				}
			}
		}
		// Do camera stuff		
		dolly.position = target.position;
		dolly.rotation = target.rotation;	
		
		if (Input.GetMouseButton(1))
		{
			hRot += Input.GetAxis("Mouse X") * mouseSense;
			vRot -= Input.GetAxis("Mouse Y") * mouseSense;
		}
		
		vRot = Mathf.Clamp(vRot, vRotMin, vRotMax);
		
		distance -= Input.GetAxis("Mouse ScrollWheel") * mouseScrollSense;
		distance = Mathf.Clamp(distance, distMin, distMax);
				
		dolly.rotation = Quaternion.Euler(vRot,hRot,0);
		
		cam.localPosition = new Vector3(0,0,-distance);
		//cam.LookAt(target);
		

	}
	
	public void jumpEnd()
	{
		jumping = false;
	}
	public void idleEnd()
	{
		idling = false;
	}
	
	public void spawnCoins(int _number)
	{
		for (int i=0;i < _number; i++)
		{
			
            Instantiate(pfCoin, new Vector3(0, 9, i * 2.0F), Quaternion.identity);
        }
	}
	public void OnGUI()
	{
		if (!gameRunning)
		{
			GUI.BeginGroup(new Rect(20, 20, 200, 200));
			GUI.Label(new Rect(35,5,190, 20), "Anzahl der Coins");
			hSliderValue = Mathf.Round(GUI.HorizontalSlider(new Rect (5, 35, 150, 20), hSliderValue, 0.0f, 10.0f));
			GUI.Label(new Rect(165,30,15,20), hSliderValue.ToString());
			if (GUI.Button(new Rect(10, 55, 50, 20), "Start"))
			{
            	gameRunning = true;
				spawnCoins((int)hSliderValue);
			}
			GUI.EndGroup();
		}
	}

		
}
