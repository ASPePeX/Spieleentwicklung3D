using UnityEngine;
using System.Collections;

public class TestClassSuper : MonoBehaviour {
	
	protected float rotation;
	
	public void Start()
	{
		rotation = 5.0f;
	}
		
	public void Update()
	{
		transform.Rotate(0,rotation,0);
	}
}
