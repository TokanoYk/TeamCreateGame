using UnityEngine;
using System.Collections;

/// <summary>Title画面の表示スクリプト</summary>

public class Title : MonoBehaviour {

	//	合わせている場所
	public int SelectNumber = 0;

	public AudioClip open;
	public AudioClip close;
	public AudioClip cursor;

	//	キーが押されたかの判定
	public bool OnKey = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Select ();
	}

	void Select()
	{
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			SelectNumber ++;
			//audio.volume = 0.2f;
			//audio.PlayOneShot(cursor);

			if(SelectNumber > 1)
			{
				SelectNumber = 0;
			}
			
			Debug.Log(SelectNumber);
		}
		
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			SelectNumber --;
			//audio.volume = 0.2f;
			//audio.PlayOneShot(cursor);

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
				audio.volume = 0.5f;
				audio.PlayOneShot(open);
				FadeManager.Instance.LoadLevel("StageSelect", 1.0f);
				OnKey = true;
			}

			//	終了する
			if(SelectNumber == 1)
			{
				audio.volume = 0.5f;
				audio.PlayOneShot(close);
				Invoke("Close",0.8f);
				OnKey = true;
			}
		}
	}

	void Close()
	{
		Application.Quit();
	}
}
