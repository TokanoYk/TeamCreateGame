using UnityEngine;
using System.Collections;

/// <summary>Title画面の表示スクリプト</summary>

public class Title : MonoBehaviour {

	//	合わせている場所
	public int SelectNumber = 0;

	public AudioClip Page;

	//	SelectNumberでアニメーション取得する

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
				audio.PlayOneShot(Page);
				FadeManager.Instance.LoadLevel("StageSelect", 1.0f);
				//OnKey = true;
			}

			//	終了する
			if(SelectNumber == 1)
			{
				audio.PlayOneShot(Page);
				Application.Quit();
				//OnKey = true;
			}
		}
	}


}
