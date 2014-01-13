using UnityEngine;
using System.Collections;

public class importData : MonoBehaviour
{
	
	private string[] aExternalData = {};
		
	// Use this for initialization
	void Start ()
	{
	
		string filename = "ExternalData/ExternalData.txt";
		string iniData = "";
		string prefix = "";

		if (!Application.isWebPlayer)
		{
			prefix = "file://";
			Debug.Log("not a Webplayer");
		}
		var pathname = prefix + Application.dataPath + "/../" + filename;
		Debug.Log (pathname);
		
		StartCoroutine (DoWWW (pathname));
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	private IEnumerator DoWWW (string path)
	{

		WWW www = new WWW (path);
		yield return www;

		print (www.text);

	}
}

