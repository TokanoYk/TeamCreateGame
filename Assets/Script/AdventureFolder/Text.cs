using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Text : MonoBehaviour {
	/*
	//	画像表示順
	public int Depth = 0;

	//	-------------------------------------------
	//	GetComponentとか用
	//	-------------------------------------------
	/// <summary>GUIStyleの宣言</summary>
	public GUIStyle LabelStyle;

	//	-------------------------------------------
	//	テキスト表示用
	//	-------------------------------------------
	/// <summary>セリフのカウント</summary>
	int count = 0;
	/// <summary>１文字ずつ表示するスピード</summary>
	float drawTextSpeed = 0.01f;
	/// <summary>クリックしてからの時間</summary>
	float TimeMeasurement = 0.0f;
	/// <summary>セリフ格納</summary>
	string storage = "";
	/// <summary>文字列が何番目か</summary>
	int textLenght = 0;

	//	-------------------------------------------
	//	テキスト(後々ファイル読み込み)
	//	-------------------------------------------
	//public TextAsset textData;
	public string textData;

	public List<string> message;

	// Use this for initialization
	void Start () {
		textData = "//text/text.txt";
		message = new List<string> ();
	}
	
	// Update is called once per frame
	void Update () {

		texiinit ();
		//	Addで書き出し？
		message.Add ("textData");
		message.Add ("texts");
	}

	void texiinit()
	{
		//	ファイル読み込み
		var date = File.ReadAllText(textData);
		//	分割
		IEnumerable<string> texts = date.Split('\n').
			SelectMany(x => x.Split(',')).ToArray();

		message.Add ("texts");
	}

	void NovelPart()
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			count ++ ;
			textLenght = 0;

			if(count >= 100)
			{

			}
		}
		TimeMeasurement += Time.deltaTime;

		if(TimeMeasurement > drawTextSpeed)
		{
			if(count == 1)
			{
				if(message[0].Length <= textLenght)
				{
					storage += message[0].Substring(textLenght,1);
				}
			}
			textLenght++;
			TimeMeasurement = 0.0f;
		}



	}

	void OnGUI()
	{
		GUI.depth = Depth;

		float sw = Screen.width;
		float sh = Screen.height;

		//	文字列表示
		Rect mozi = new Rect (sw /2 -180, sh /2 + 120, sw / 2, sh / 2);
		GUI.Label (mozi, storage, LabelStyle);
	}
	*/
}
