using UnityEngine;
using System.Collections;

public class NovelPatt : MonoBehaviour {
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
	float timeMeasurement = 0.0f;
	/// <summary>セリフ格納</summary>
	string storage = "";
	/// <summary>文字列が何番目か</summary>
	int textLenght = 0;

	//	-------------------------------------------
	//	セリフ格納
	//	後々テキスト読み込み化
	//	-------------------------------------------
	/// <summary>主人公</summary>
	string[] NoClearPart = {
		"ただいまー",
		"お兄ちゃん、お帰り!","お帰りなさい、ユークさん。\nお邪魔しています。",
		"？　ネネア、彼女は？","ミリアさんだよ。\nお兄ちゃんに用があるんだって！",
		"初めまして、兄のユークです。\n俺に用って、何ですか？",
		"…ネネアちゃん、すみません。どこか人を気にせず話せる場所はありませんか？",
		"この家使っても大丈夫ですよ。お母さんたちはしばらく帰ってこないだろうし\nわたしも夕飯の買い出しに行くので！",
		"",
		"ネネア！グラタンがいい！","行ってらっしゃい、ミリア。気をつけるんだぞ。","それで、話って何ですか？",
		"ええと…、どういうことですか？","まあ、旅の間に何度か見かけましたけど…。\nそれが何か関係あるんですか？",
		"そ、そうなんですか。","（いきなり熱くなった…。）","いや、無理です。\nお引き取り下さい。","そうは言われても…"
		};
	/// <summary>妹</summary>
	//string[] neneaText = {,"ミリアさんだよ。\nお兄ちゃんに用があるんだって！"};
	/// <summary>主人公</summary>
	//string[] miriaText = {};

	void OnGUI()
	{
		//	表示順の設定
		GUI.depth = Depth;

		float sw = Screen.width;
		float sh = Screen.height;

		//	文字列表示
		Rect textDraw = new Rect (sw / 2 - 180, sh / 2 + 120, sw / 2, sh / 2);
		GUI.Label (textDraw, storage, LabelStyle);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Conversation ();
	}

	/// <summary>会話を流す関数</summary>
	void Conversation()
	{
		if(Input.GetMouseButtonDown(0))
		{
			//	会話を流す
			count ++;
			//	初期化
			textLenght = 0;
			storage = "";

			if(count >= 100)
			{
				FadeManager.Instance.LoadLevel("Stage1",1.0f);
			}
		}
		timeMeasurement += Time.deltaTime;

		if(timeMeasurement > drawTextSpeed)
		{
			if(count == 0)
			{
				//if(yuukuText[0].Length > textLenght)
				{
				//	storage += yuukuText[0].Substring(textLenght,1);
				}
			}

			if(count == 1)
			{
			//	if(neneaText[0].Length > textLenght)
				{
				//	storage += neneaText[0].Substring(textLenght,1);
				}
			}

			if(count == 2)
			{
			//	if(miriaText[0].Length > textLenght)
				{
			//		storage += miriaText[0].Substring(textLenght,1);
				}
			}
			textLenght ++;
			timeMeasurement = 0.0f;

		}

	}

*/


}


