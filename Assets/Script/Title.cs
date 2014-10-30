using UnityEngine;
using System.Collections;

/// <summary>Title画面の表示スクリプト</summary>

public class Title : MonoBehaviour {

	public Texture2D TitleGraphic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Label (new Rect (0, -3, 680, 500), TitleGraphic);
	}
}
