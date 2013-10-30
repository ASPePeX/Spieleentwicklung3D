using UnityEngine;
using System.Collections;

public class CameraTracking2 : MonoBehaviour {
	
	public float distance = 4;
	public float mouseSense = 2.5f;
	public float mouseScrollSense = 1.0f;
	
	private int vRotMax = 60;
	private int vRotMin = -20;
	
	private float distMax = 10.0f;
	private float distMin = 1.2f;
	
	private Transform target;
	private Transform cam;
	private Transform dolly;
	
	private float hRot;
	private float vRot;
	
	// Use this for initialization
	void Start () {
		target = GameObject.Find("MeshHead").transform;
		cam = transform.FindChild ("Camera");
		dolly = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		dolly.position = target.position;
		dolly.rotation = target.rotation;	
		
		hRot += Input.GetAxis("Mouse X") * mouseSense;
		
		vRot -= Input.GetAxis("Mouse Y") * mouseSense;
		vRot = Mathf.Clamp(vRot, vRotMin, vRotMax);
		
		distance -= Input.GetAxis("Mouse ScrollWheel") * mouseScrollSense;
		distance = Mathf.Clamp(distance, distMin, distMax);
				
		dolly.localRotation = Quaternion.Euler(vRot,hRot,0);
		
		cam.localPosition = new Vector3(0,0,-distance);
	
		cam.LookAt(target);
	}
}
