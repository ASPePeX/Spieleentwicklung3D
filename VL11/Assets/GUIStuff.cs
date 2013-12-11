using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GUIStuff : MonoBehaviour {
	
	string bla = "Textblub";
	float slidy = 10f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI ()
	{
		GUI.BeginGroup(new Rect(20, 20, 210, 310));
		GUI.Label						(new Rect(5,	5,			200, 20), 	"Hallo Worlds");
		GUI.Box							(new Rect(5, 	5 + 30,		200, 100), 	"Bla");
		bool b = GUI.Button				(new Rect(10, 	5 + 50, 	190, 75),	new GUIContent("Bütton", "Tooltip"));
		if (b)
		{
			Debug.Log("Button pressed");
		}
		bla = GUI.TextField				(new Rect(5,	5 + 160,	200, 100),	bla, 20);
		
		slidy = GUI.HorizontalSlider	(new Rect(5,	5 + 270,	200, 30),	slidy, 1,100);
		GUI.EndGroup();
	}
}
