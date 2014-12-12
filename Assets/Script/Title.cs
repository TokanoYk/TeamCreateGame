using UnityEngine;
using System.Collections;

/// <summary>Title画面の表示スクリプト</summary>

public class Title : MonoBehaviour {
	


	//	カーソル
	public Texture2D Cursor;

	public Texture2D ScenarioTitleRed;
	public Texture2D ScenarioTitleBlue;

	//	合わせている場所
	int SelectNumber = 0;

	//　エンターが押された
	bool OnKey = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Select ();
	}

	void OnGUI()
	{
		float sw = Screen.width;
		float sh = Screen.height;
		
		if(!OnKey)
		{
			//	１
			GUI.Label (new Rect (sw / 2 - 250 , sh / 2, 200, 100), ScenarioTitleRed);
			//	２
			GUI.Label (new Rect (sw / 2 - 250 , sh / 2 + 100, 200, 100), ScenarioTitleBlue);
			
			if(SelectNumber == 0)
			{
				GUI.Label (new Rect (sw / 2 - 300 , sh / 2 , 50, 50), Cursor);
			}
			if(SelectNumber == 1)
			{
				GUI.Label (new Rect (sw / 2 - 300 , sh / 2 + 100, 50, 50), Cursor);
			}
		}
	}

	void Select()
	{
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			SelectNumber ++;
			
			if(SelectNumber > 1)
			{
				SelectNumber = 0;
			}
			
			Debug.Log(SelectNumber);
		}
		
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			SelectNumber --;
			if(SelectNumber < 0)
			{
				SelectNumber = 1;
			}
			Debug.Log(SelectNumber);
		}
		
		if(Input.GetKeyDown(KeyCode.Return))
		{
			if(SelectNumber == 0)
			{
				FadeManager.Instance.LoadLevel("StageSelect", 1.0f);
				OnKey = true;
			}

			//	終了する
			if(SelectNumber == 1)
			{
				Application.Quit();
				OnKey = true;
			}
		}
	}


}
