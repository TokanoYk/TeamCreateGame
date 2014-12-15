using UnityEngine;
using System.Collections;

public class ClearNovelPart : MonoBehaviour {

		
	//	-------------------------------------------
	//	GetComponentとか用
	//	-------------------------------------------
	/// <summary>GUIStyleの宣言</summary>
	public GUIStyle LabelStyle;
	
	//	キャラクターの宣言
	private DrawYuuku _yuuku;
	public GameObject YuukuObject;
	
	private DrawMiria _miria;
	public GameObject MiriaObject;

	//	ネームボックスの表示用
	private DrawName _namebox;
	public GameObject NameBoxObject;


	//	-------------------------------------------
	//	オーディオ関連
	//	-------------------------------------------
	public AudioClip dash;
	
	bool one = false;

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
	string[] TextData = {
		"くそっ逃げられた…！",
		"ユークさん！何があったんですか？！",
		"…ミリアさん…。…ネネアが、消えました。",
		"そんな…ネネアちゃんが…。",
		"俺、「助けて」って言ったあいつを、助けられなかった…。","" +
		"あげく、あの変な蟲を取り逃した…！",
		"…ユークさん、恐らくその蟲は先日話した\n『本ノ蟲』の親玉の一匹だと思います。",
		"あれが、『本ノ蟲』…？",
		"ミリアさん、昨日の話、引き受けます。\nネネアを消したあいつらが、俺は許せない…！",
		"ユークさん…。\nありがとうございます。\n私も、できる限りのサポートはします。",
		"それに、『本ノ蟲』を駆除し物語がもとに戻れば\nもしかしたら消えた人たちが戻ってくるかもしれません。",
		"ですから頑張りましょうね？\nよろしくお願いします。",
		"！\n…可能性があるなら、俺はそれに賭けます。\nこちらこそ、よろしくお願いします。",
		"…待ってろよ、ネネア…！"
	};
	
	void OnGUI()
	{	
		float sw = Screen.width;
		float sh = Screen.height;
		
		//	文字列表示
		Rect textDraw = new Rect (sw / 2 - 180, sh / 2 + 120, sw / 2, sh / 2);
		GUI.Label (textDraw, storage, LabelStyle);
	}
	
	// Use this for initialization
	void Start () {
		_yuuku = YuukuObject.GetComponent<DrawYuuku> ();
		_miria = MiriaObject.GetComponent<DrawMiria> ();
		_namebox = NameBoxObject.GetComponent<DrawName> ();
	}
	
	// Update is called once per frame
	void Update () {
		Conversation ();
	}
	
	/// <summary>会話を流す関数</summary>
	void Conversation()
	{
		//if(Input.GetMouseButtonDown(0))
		if(Input.GetKeyDown(KeyCode.Return))
		{
			//	会話を流す
			count ++;
			//	初期化
			textLenght = 0;
			storage = "";

			//	12で終了
			if(count >= 14)
			{
				FadeManager.Instance.LoadLevel("StaffRoll",1.0f);
				Debug.Log("終了");

				_namebox.yuukuName = false;
				_namebox.hide = true;

				_miria.smile = false;
				_miria.hide = true;

				_yuuku.mortifying = false;
				_yuuku.hide = true;

			}
		}
		timeMeasurement += Time.deltaTime;
		
		if(timeMeasurement > drawTextSpeed)
		{
			//	ユ：逃げられた
			if(count == 0)
			{
				_namebox.yuukuName = true;
				_yuuku.mortifying = true;

				if(TextData[0].Length > textLenght)
				{
					storage += TextData[0].Substring(textLenght,1);
				}
			}
			
			//	ミ：ユークさん！
			if(count == 1)
			{
				_namebox.yuukuName = false;
				_namebox.miriaName = true;
				
				_miria.impatience = true;

				if(!one)
				{
					audio.PlayOneShot(dash);
					one = true;
				}

				if(TextData[1].Length > textLenght)
				{
					storage += TextData[1].Substring(textLenght,1);
				}
			}
			
			//	ユ：ミリアさん…
			if(count == 2)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;
				
				_yuuku.mortifying = false;
				_yuuku.cry = true;

				one = false;

				if(TextData[2].Length > textLenght)
				{
					storage += TextData[2].Substring(textLenght,1);
				}
			}
			
			//	ミ：そんな…
			if(count == 3)
			{
				_namebox.yuukuName = false;
				_namebox.miriaName = true;
				
				_miria.impatience = false;
				_miria.cry = true;

				if(TextData[3].Length > textLenght)
				{
					storage += TextData[3].Substring(textLenght,1);
				}
			}
			
			//	ユ：俺「助けて」って
			if(count == 4)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;

				if(TextData[4].Length > textLenght)
				{
					storage += TextData[4].Substring(textLenght,1);
				}
			}
			

			//	ユ：あげく
			if(count == 5)
			{
				_yuuku.cry = false;
				_yuuku.mortifying = true;

				if(TextData[5].Length > textLenght)
				{
					storage += TextData[5].Substring(textLenght,1);
				}
			}

			//	ミ：恐らくその…
			if(count == 6)
			{
				_namebox.yuukuName = false;
				_namebox.miriaName = true;
				
				_miria.cry = false;
				_miria.earnest = true;

				if(TextData[6].Length > textLenght)
				{
					storage += TextData[6].Substring(textLenght,1);
				}
			}

			//	ユ：あれが本の
			if(count == 7)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;
				
				_yuuku.mortifying = false;
				_yuuku.question = true;

				if(TextData[7].Length > textLenght)
				{
					storage += TextData[7].Substring(textLenght,1);
				}
			}

			//	ユ：昨日の話
			if(count == 8)
			{
				_yuuku.question = false;
				_yuuku.mortifying = true;

				if(TextData[8].Length > textLenght)
				{
					storage += TextData[8].Substring(textLenght,1);
				}
			}

			//	ミ：ありがとう
			if(count == 9)
			{
				_namebox.yuukuName = false;
				_namebox.miriaName = true;
				
				_miria.earnest = false;
				_miria.smile = true;

				if(TextData[9].Length > textLenght)
				{
					storage += TextData[9].Substring(textLenght,1);
				}
			}

			//　ミ：それに本の虫を
			if(count == 10)
			{
				_miria.smile = false;
				_miria.erinest2 = true;

				if(TextData[10].Length > textLenght)
				{
					storage += TextData[10].Substring(textLenght,1);
				}
			}

			//	ミ：ですから
			if(count == 11)
			{
				_miria.erinest2 = false;
				_miria.smile = true;

				if(TextData[11].Length > textLenght)
				{
					storage += TextData[11].Substring(textLenght,1);
				}
			}

			//	ユ：可能性があるなら
			if(count == 12)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;
				
				_yuuku.mortifying = false;
				_yuuku.impatience = true;


				if(TextData[12].Length > textLenght)
				{
					storage += TextData[12].Substring(textLenght,1);
				}
			}

			//	ユ：待ってろよ
			if(count == 13)
			{
				_yuuku.impatience = false;
				_yuuku.mortifying = true;

				if(TextData[13].Length > textLenght)
				{
					storage += TextData[13].Substring(textLenght,1);
				}
			}

			textLenght ++;
			timeMeasurement = 0.0f;
			
		}
		
	}


}
