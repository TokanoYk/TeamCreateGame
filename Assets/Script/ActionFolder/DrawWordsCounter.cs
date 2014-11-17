using UnityEngine;
using System.Collections;

public class DrawWordsCounter : MonoBehaviour {
	
	public int words = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		DrawCounter ();
	}

	void DrawCounter()
	{
		guiText.text = "<Color=black>【言葉】：" + words.ToString() + "／16</Color>";
		
	}
}
