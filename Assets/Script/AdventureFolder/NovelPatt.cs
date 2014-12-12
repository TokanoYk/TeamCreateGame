using UnityEngine;
using System.Collections;

public class NovelPatt : MonoBehaviour {

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

	private DrawNenea _nenea;
	public GameObject NeneaObject;

	private DrawMoth _moth;
	public GameObject MothObject;

	//	背景の宣言
	private ChangeBackground _background;
	public GameObject BackgroundObject;

	//	ネームボックスの表示用
	private DrawName _namebox;
	public GameObject NameBoxObject;

	//	-------------------------------------------
	//	オーディオ関連
	//	-------------------------------------------
	public AudioClip door;
	public AudioClip dash;

	bool one = false;

	//	-------------------------------------------
	//	テキスト表示用
	//	-------------------------------------------
	/// <summary>セリフのカウント</summary>
	public int count = 0;
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
		"ユークの家",
		"ただいまー",
		"お兄ちゃん、おかえり!",
		"お帰りなさい、ユークさん。\nお邪魔しています。",
		"？　ネネア、彼女は？",
		"ミリアさんだよ。\nお兄ちゃんに用があるんだって！",
		"初めまして、ミリアです。",
		"初めまして、兄のユークです。\n俺に用って、何ですか？",
		"…ネネアちゃん、すみません。\nどこか人を気にせず話せる場所はありませんか？",
		"この家使っても大丈夫ですよ。\nお母さんたちはしばらく帰ってこないだろうし\nわたしも夕飯の買い出しに行くので！",
		"ありがとうございます。",
		"ネネア！グラタンがいい！",
		"却下！今日はシチューなの！",
		"わたし、そろそろお買い物行ってくるね。\nミリアさん、ごゆっくりどうぞ～",
		"ありがとうございます。\n行ってらっしゃい、ミリアちゃん。",
		"行ってらっしゃい、ミリア。\n気をつけるんだぞ。",

		"それで、話って何ですか？",
		"旅から戻って来たばかりで、お疲れのところすみません。\nですが、事は一刻を争います。",
		"ええと…、どういうことですか？",
		"最近、突然消える人や村などが増えていることをご存知\nですか？",
		"まあ、旅の間に何度か見かけましたけど…。\nそれが何か関係あるんですか？",
		"大ありです。\nこれは、この世界が消滅へと進んで行っていることを\n表しています。",
		"それも自然にではありません。\nある『害虫』が原因でです！",
		"そ、そうなんですか。",
		"（いきなり熱くなった…。）",
		"その害虫…私たちは『本ノ蟲』と呼んでいますが、\nそいつらは物語にある【言葉】を食べてしまっているの\nです！",
		"そのせいでこの本の読者が減り世界が消滅の危機に\n陥っています！",
		"なので！\n『本ノ蟲』を排除し、物語にできた【穴】を埋めてくだ\nさい！",
		"いや、無理です。\nお引き取り下さい。",
		"引けません！お願いします！",
		"そうは言われても…",
		"俺、物語の詳細を知らないですし、剣は一応あるけど\nただの放浪者にすぎません。\nもっと適任が居るんじゃないですか？",
		"現状、あなた以外に物語の再構成を行える立ち位置の者\nは居ないのです。",
		"はぁ…。",
		"…今日のところは帰りますがまた明日来ますので。\nよい返事を期待しています。",
		"…どうぞご勝手に。",

		"翌日","お兄ちゃん、ミリアさん今日も来るんだよね？",
		"らしいな。",
		"じゃあおいしいお菓子用意しとかないとだね！\n何にしようかなぁ？",
		"（はぁ…。憂鬱だ。）",
		"キャア！",
		"ネネア？",
		"（なんだ、こいつ！？）",
		"お兄ちゃん、助けてっ！",
		"待ってろ！すぐ助けてやる！",
		"お兄ちゃっ…！",
		"ネネアッ！",
		"くそっ！逃げんな！！",
		"！？　なんだ…これ。こんな森じゃなかったはず…！",
		"あっ！お前、逃げんなって！",
		"くそ！待ってろ！ネネア！"
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
		_nenea = NeneaObject.GetComponent<DrawNenea> ();
		_moth = MothObject.GetComponent<DrawMoth> ();

		_background = BackgroundObject.GetComponent<ChangeBackground> ();
		_namebox = NameBoxObject.GetComponent<DrawName> ();
	}
	
	// Update is called once per frame
	void Update () {
		Conversation ();
	}

	/// <summary>会話を流す関数</summary>
	void Conversation()
	{
		//	Sを押すとスキップ
		if(Input.GetKeyDown(KeyCode.S))
		{
			FadeManager.Instance.LoadLevel("Stage1",1.0f);
		}

		//if(Input.GetMouseButtonDown(0))
		if(Input.GetKeyDown(KeyCode.Return))
		{
			//	会話を流す
			count ++;
			//	初期化
			textLenght = 0;
			storage = "";

			if(count >= 52)
			{
				FadeManager.Instance.LoadLevel("Stage1",1.0f);
			}
		}
		timeMeasurement += Time.deltaTime;

		if(timeMeasurement > drawTextSpeed)
		{
			//	ナレ
			if(count == 0)
			{
				if(TextData[0].Length > textLenght)
				{
					storage += TextData[0].Substring(textLenght,1);
				}
			}

			//	ユ：ただいま
			if(count == 1)
			{
				_namebox.yuukuName = true;
				_yuuku.smile = true;

				if(!one)
				{
					audio.PlayOneShot(door);
					one = true;
				}

				if(TextData[1].Length > textLenght)
				{
					storage += TextData[1].Substring(textLenght,1);
				}
			}

			//	ネ：おかえり
			if(count == 2)
			{
				_namebox.yuukuName = false;
				_namebox.neneaName = true;

				_nenea.happy = true;

				one = false;

				if(TextData[2].Length > textLenght)
				{
					storage += TextData[2].Substring(textLenght,1);
				}
			}

			//	ミ：おかえり
			if(count == 3)
			{
				_namebox.neneaName = false;
				_namebox.nazo = true;

				_miria.shadow = true;

				if(TextData[3].Length > textLenght)
				{
					storage += TextData[3].Substring(textLenght,1);
				}
			}

			//	ユ：彼女は？
			if(count == 4)
			{
				_namebox.nazo = false;
				_namebox.yuukuName = true;

				_yuuku.smile = false;
				_yuuku.question = true;

				if(TextData[4].Length > textLenght)
				{
					storage += TextData[4].Substring(textLenght,1);
				}
			}

			//	ネ：ミリアさんだよ
			if(count == 5)
			{
				_namebox.yuukuName = false;
				_namebox.neneaName = true;

				if(TextData[5].Length > textLenght)
				{
					storage += TextData[5].Substring(textLenght,1);
				}
			}

			//	ミ：初めまして
			if(count == 6)
			{
				_namebox.neneaName = false;
				_namebox.miriaName = true;

				_miria.shadow = false;
				_miria.smile = true;

				if(TextData[6].Length > textLenght)
				{
					storage += TextData[6].Substring(textLenght,1);
				}
			}

			//	ユ：初めまして
			if(count == 7)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;

				if(TextData[7].Length > textLenght)
				{
					storage += TextData[7].Substring(textLenght,1);
				}
			}

			//	ミ：ネネアちゃんすみません
			if(count == 8)
			{
				_namebox.yuukuName = false;
				_namebox.miriaName = true;

				_miria.smile = false;
				_miria.cry = true;

				if(TextData[8].Length > textLenght)
				{
					storage += TextData[8].Substring(textLenght,1);
				}
			}

			//	ネ：この家
			if(count == 9)
			{
				_namebox.miriaName = false;
				_namebox.neneaName = true;

				if(TextData[9].Length > textLenght)
				{
					storage += TextData[9].Substring(textLenght,1);
				}
			}

			//	ミ：ありがとう
			if(count == 10)
			{
				_namebox.neneaName = false;
				_namebox.miriaName = true;

				_miria.cry = false;
				_miria.smile = true;

				if(TextData[10].Length > textLenght)
				{
					storage += TextData[10].Substring(textLenght,1);
				}
			}

			//	ユ：グラタン
			if(count == 11)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;

				_yuuku.question = false;
				_yuuku.gratan = true;

				if(TextData[11].Length > textLenght)
				{
					storage += TextData[11].Substring(textLenght,1);
				}
			}

			//	ネ：却下
			if(count == 12)
			{
				_namebox.yuukuName = false;
				_namebox.neneaName = true;

				_nenea.happy = false;
				_nenea.neglect = true;

				if(TextData[12].Length > textLenght)
				{
					storage += TextData[12].Substring(textLenght,1);
				}
			}

			//	ネ：わたしそろそろ買い物
			if(count == 13)
			{
				_nenea.neglect = false;
				_nenea.smile = true;

				if(TextData[13].Length > textLenght)
				{
					storage += TextData[13].Substring(textLenght,1);
				}
			}

			//	ミ：ありがとうございます
			if(count == 14)
			{
				_namebox.neneaName = false;
				_namebox.miriaName = true;

				if(TextData[14].Length > textLenght)
				{
					storage += TextData[14].Substring(textLenght,1);
				}
			}

			//	ユ：行ってらっしゃい
			if(count == 15)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;

				_yuuku.gratan = false;
				_yuuku.smile = true;

				if(TextData[15].Length > textLenght)
				{
					storage += TextData[15].Substring(textLenght,1);
				}
			}


			//	ユ：それで話って
			if(count == 16)
			{
				_nenea.smile = false;
				_nenea.hide = true;
				
				_yuuku.smile = false;
				_yuuku.question = true;

				if(!one)
				{
					one = true;
					audio.PlayOneShot(door);
				}

				if(TextData[16].Length > textLenght)
				{
					storage += TextData[16].Substring(textLenght,1);
				}
			}

			//	ミ：旅から
			if(count == 17)
			{

				one = false;

				_namebox.yuukuName = false;
				_namebox.miriaName = true;

				_miria.smile = false;
				_miria.earnest = true;

				if(TextData[17].Length > textLenght)
				{
					storage += TextData[17].Substring(textLenght,1);
				}
			}

			//	ユ：ええと…
			if(count == 18)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;

				if(TextData[18].Length > textLenght)
				{
					storage += TextData[18].Substring(textLenght,1);
				}
			}

			//	ミ：最近突然消える
			if(count == 19)
			{
				_namebox.yuukuName = false;
				_namebox.miriaName = true;

				if(TextData[19].Length > textLenght)
				{
					storage += TextData[19].Substring(textLenght,1);
				}
			}

			//	ユ：まぁ…
			if(count == 20)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;

				if(TextData[20].Length > textLenght)
				{
					storage += TextData[20].Substring(textLenght,1);
				}
			}

			//	ミ：大有りです
			if(count == 21)
			{
				_namebox.yuukuName = false;
				_namebox.miriaName = true;

				_miria.earnest = false;
				_miria.erinest2 = true;

				if(TextData[21].Length > textLenght)
				{
					storage += TextData[21].Substring(textLenght,1);
				}
			}

			//	ミ：それも自然に
			if(count == 22)
			{
				if(TextData[22].Length > textLenght)
				{
					storage += TextData[22].Substring(textLenght,1);
				}
			}

			//	ユ：そうですか
			if(count == 23)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;

				_yuuku.question = false;
				_yuuku.amazed = true;

				if(TextData[23].Length > textLenght)
				{
					storage += TextData[23].Substring(textLenght,1);
				}
			}

			//	ユ：熱くなった…
			if(count == 24)
			{
				if(TextData[24].Length > textLenght)
				{
					storage += TextData[24].Substring(textLenght,1);
				}
			}

			//	ミ：その害虫
			if(count == 25)
			{
				_namebox.yuukuName = false;
				_namebox.miriaName = true;

				if(TextData[25].Length > textLenght)
				{
					storage += TextData[25].Substring(textLenght,1);
				}
			}

			//	ミ：そのせいで
			if(count == 26)
			{
				if(TextData[26].Length > textLenght)
				{
					storage += TextData[26].Substring(textLenght,1);
				}
			}

			//	ミ：なので
			if(count == 27)
			{
				if(TextData[27].Length > textLenght)
				{
					storage += TextData[27].Substring(textLenght,1);
				}
			}

			//	ユ：いや無理です
			if(count == 28)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;

				if(TextData[28].Length > textLenght)
				{
					storage += TextData[28].Substring(textLenght,1);
				}
			}

			//	ミ：引けません
			if(count == 29)
			{
				_namebox.yuukuName = false;
				_namebox.miriaName = true;

				_miria.erinest2 = false;
				_miria.appeal = true;

				if(TextData[29].Length > textLenght)
				{
					storage += TextData[29].Substring(textLenght,1);
				}
			}

			//	ユ：そうは言われても
			if(count == 30)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;

				if(TextData[30].Length > textLenght)
				{
					storage += TextData[30].Substring(textLenght,1);
				}
			}

			//	ユ：物語の詳細を
			if(count == 31)
			{
				if(TextData[31].Length > textLenght)
				{
					storage += TextData[31].Substring(textLenght,1);
				}
			}

			//	ミ：現状あなた以外に
			if(count == 32)
			{
				_namebox.yuukuName = false;
				_namebox.miriaName = true;

				_miria.appeal = false;
				_miria.earnest = true;

				if(TextData[32].Length > textLenght)
				{
					storage += TextData[32].Substring(textLenght,1);
				}
			}

			//	ユ：はぁ
			if(count == 33)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;

				if(TextData[33].Length > textLenght)
				{
					storage += TextData[33].Substring(textLenght,1);
				}
			}

			//	ミ：今日のところは
			if(count == 34)
			{
				_namebox.yuukuName = false;
				_namebox.miriaName = true;

				if(TextData[34].Length > textLenght)
				{
					storage += TextData[34].Substring(textLenght,1);
				}
			}

			//	ユ：ご勝手に
			if(count == 35)
			{
				_namebox.miriaName = false;
				_namebox.yuukuName = true;

				_yuuku.amazed = false;
				_yuuku.drop = true;

				if(TextData[35].Length > textLenght)
				{
					storage += TextData[35].Substring(textLenght,1);
				}
			}




			//	ナレ
			if(count == 36)
			{
				_namebox.yuukuName = false;
				_namebox.hide = true;

				_miria.earnest = false;
				_miria.hide = true;
				
				_yuuku.drop = false;
				_yuuku.hide = true;

				if(TextData[36].Length > textLenght)
				{
					storage += TextData[36].Substring(textLenght,1);
				}
			}

			//	ネ：お兄ちゃん
			if(count == 37)
			{
				_namebox.hide = false;
				_namebox.neneaName = true;

				_nenea.hide = false;
				_nenea.happy = true;

				if(TextData[37].Length > textLenght)
				{
					storage += TextData[37].Substring(textLenght,1);
				}
			}

			//	ユ：らしいな
			if(count == 38)
			{
				_namebox.neneaName = false;
				_namebox.yuukuName = true;

				_yuuku.hide = false;
				_yuuku.drop = true;

				if(TextData[38].Length > textLenght)
				{
					storage += TextData[38].Substring(textLenght,1);
				}
			}

			//	ネ：じゃあおいしいお菓子
			if(count == 39)
			{
				_namebox.yuukuName = false;
				_namebox.neneaName = true;

				if(TextData[39].Length > textLenght)
				{
					storage += TextData[39].Substring(textLenght,1);
				}
			}

			//	ユ：憂鬱だ
			if(count == 40)
			{
				_namebox.neneaName = false;
				_namebox.yuukuName = true;

				_yuuku.drop = false;
				_yuuku.amazed = true;
				
				_nenea.happy = false;
				_nenea.hide = true;

				if(TextData[40].Length > textLenght)
				{
					storage += TextData[40].Substring(textLenght,1);
				}
			}

			//	ネ：きゃあ！
			if(count == 41)
			{
				_namebox.yuukuName = false;
				_namebox.neneaName = true;

				if(TextData[41].Length > textLenght)
				{
					storage += TextData[41].Substring(textLenght,1);
				}
			}

			//	ユ：ネネア？
			if(count == 42)
			{
				_namebox.neneaName = false;
				_namebox.yuukuName = true;

				_yuuku.amazed = false;
				_yuuku.question = true;

				if(TextData[42].Length > textLenght)
				{
					storage += TextData[42].Substring(textLenght,1);
				}
			}

			//	ユ：何だこいつ
			if(count == 43)
			{
				_moth.draw = true;
				//	ネネア移動の変数
				_nenea.moveOn = true;

				_yuuku.question = false;
				_yuuku.impatience = true;
				
				_nenea.hide = false;
				_nenea.help = true;

				if(TextData[43].Length > textLenght)
				{
					storage += TextData[43].Substring(textLenght,1);
				}
			}

			//	ネ：助けて！
			if(count == 44)
			{
				_namebox.yuukuName = false;
				_namebox.neneaName = true;

				if(TextData[44].Length > textLenght)
				{
					storage += TextData[44].Substring(textLenght,1);
				}
			}

			//	ユ：待ってろ！
			if(count == 45)
			{
				_namebox.yuukuName = true;

				_yuuku.impatience = false;
				_yuuku.mortifying = true;

				if(TextData[45].Length > textLenght)
				{
					storage += TextData[45].Substring(textLenght,1);
				}
			}

			//	ネ：お兄ちゃ…
			if(count == 46)
			{
				_namebox.yuukuName = false;
				_namebox.neneaName = true;

				_nenea.help = false;
				_nenea.cry = true;

				one = false;

				if(TextData[46].Length > textLenght)
				{
					storage += TextData[46].Substring(textLenght,1);
				}
			}

			//	ユ：ネネア！
			if(count == 47)
			{
				_namebox.neneaName = false;
				_namebox.yuukuName = true;

				_moth.draw = false;
				_moth.hide = true;

				_nenea.cry = false;
				_nenea.hide = true;
				
				_yuuku.mortifying = false;
				_yuuku.impatience = true;

				if(!one)
				{
					audio.PlayOneShot(door);
					one = true;
				}

				if(TextData[47].Length > textLenght)
				{
					storage += TextData[47].Substring(textLenght,1);
				}
			}

			//	ユ：クソ！逃げるな！
			if(count == 48)
			{
				_yuuku.impatience = false;
				_yuuku.mortifying = true;

				one = false;

				if(TextData[48].Length > textLenght)
				{
					storage += TextData[48].Substring(textLenght,1);
				}
			}

			//	ユ：なんだこれ（背景）
			if(count == 49)
			{
				_background.home = false;
				_background.forest = true;
				
				_yuuku.mortifying = false;
				_yuuku.impatience = true;

				if(!one)
				{
					audio.PlayOneShot(door);
					one = true;
				}

				if(TextData[49].Length > textLenght)
				{
					storage += TextData[49].Substring(textLenght,1);
				}
			}

			//	ユ：逃げるな！
			if(count == 50)
			{
				_yuuku.impatience = false;
				_yuuku.mortifying = true;

				one = false;


				if(TextData[50].Length > textLenght)
				{
					storage += TextData[50].Substring(textLenght,1);
				}
			}

			//	ユ：くそ！
			if(count == 51)
			{
				if(!one)
				{
					audio.PlayOneShot(dash);
					one = true;
				}

				if(TextData[51].Length > textLenght)
				{
					storage += TextData[51].Substring(textLenght,1);
				}
			}

			textLenght ++;
			timeMeasurement = 0.0f;

		}

	}




}


