using UnityEngine;
using System.Collections;

//	マウスカーソルの変更
public class MouseCursor : MonoBehaviour {

	public Texture2D cousorTexture;
	Vector2 MouseSpot;



	// Use this for initialization
	void Awake ()
	{
		MouseSpot = new Vector2 (12f, 8f);
	}

	void ChangeMouse()
	{
		Cursor.SetCursor (cousorTexture, MouseSpot, CursorMode.Auto);

	}

	// Update is called once per frame
	void Update () {
		ChangeMouse ();
	}
}
