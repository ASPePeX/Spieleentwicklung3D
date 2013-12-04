using UnityEngine;
using System.Collections;

public class TestClassSub : TestClassSuper {

	public void Update()
	{
		base.Update();
		transform.Rotate(rotation, 0, 0);
	}
}
