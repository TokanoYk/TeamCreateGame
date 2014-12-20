using UnityEngine;
using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;

public class Text : MonoBehaviour {

	//	画像表示順
	public int Depth = 0;

	//	-------------------------------------------
	//	グラフィックの指定
	//	-------------------------------------------
	//public Texture2D TextBox;


	//	-------------------------------------------
	//	判定用
	//	-------------------------------------------
	//bool Hide = false;

	//	-------------------------------------------
	//	GetComponentとか用
	//	-------------------------------------------
	/// <summary>GUIStyleの宣言</summary>
	public GUIStyle LabelStyle;

	//	-------------------------------------------
	//	テキスト表示用
	//	-------------------------------------------
	//	文字列を格納する
	string storage = "";

	//	なん文字目を追加してるか
	private int currentNum = 0;
	//	String配列
	private int textLine = 0;

	//	-------------------------------------------
	//	テキスト
	//	-------------------------------------------
	public TextAsset _text;
	public IEnumerable<string> layoutInfo;
	public IEnumerable<string> LineBreak;
	private string useText;
	private int insertNum;

	private string Name;
	private string Id;
	private string Usetext;

	//layoutInfo.elemtnat(textline) == string text[textline]; 
	

	void OnGUI()
	{
		GUI.depth = Depth;
		
		float sw = Screen.width;
		float sh = Screen.height;
		
		//	文字列表示
		Rect mozi = new Rect (sw /2 -180, sh /2 + 120, sw / 2, sh / 2);
		GUI.Label (mozi, storage, LabelStyle);
	}

	// Use this for initialization
	void Start()
	{
		this.readText ();

		textLine = 0;

		currentNum = 0;

		insertNum = 0;

		useText = layoutInfo.ElementAt (textLine);
		textLine++;
	}

	//	キャラ画像読み込み
	void ReadGraphic()
	{
		//	グラフィックデータパスを用意する



	}
	
	void readText()
	{
		layoutInfo = _text.text.Split ('\n');
		//1行をもう一度分割する
		foreach(var s in layoutInfo)
		{
			s.Split(',');
		}
	}

	// Update is called once per frame
	void Update () {
		NovelPart ();
	}

	void NovelPart()
	{
		/*
		 contorolbackgorund();
			if(name != キャラの名前)
			{
				//　次の行の準備
				//	UseTextに１行追加する
				if(textLine < layoutInfo.Count())
				{
					// var sample = layoutinfo.elementat(textline).split(',');
					// string name = sample[0];
					// string id = sample[1];(画像)
					// string se = sample[2];(se)
					// string usetext = sample[3];(セリフ)
				}
				textLine++;
			}
		*/
		//if(Input.GetMouseButtonDown(0))
		if(Input.GetKeyDown(KeyCode.Return))
		{
			if(useText.Count() <= storage.Count())
			{
				//　次の行の準備
				//	UseTextに１行追加する
				if(textLine < layoutInfo.Count())
				{
					// var sample = layoutinfo.elementat(textline).split(',');
					// string name = sample[0];
					// string id = sample[1];
					// string usetext = sample[2];

					//var line = layoutInfo.ElementAt(textLine).Split(',');
					//Name = line[0];
					//Id = line[1];
					//Usetext = line[2];

					useText = layoutInfo.ElementAt(textLine);
				}

				//　表示するTEXTを初期化する
				storage = "";
				
				//　usetextからstorageに対して追加する文字の番号を初期化
				currentNum = 0;
				insertNum = 0;
				//次に読み込む行を指定
				textLine++;
			}else{

				//　全文字をusetextからstorageへcopy
				if( insertNum >= 30 ) 
				{
					storage = useText;
					currentNum = useText.Count();
				}
			}

			if(textLine >= 55)
			{
				FadeManager.Instance.LoadLevel("Stage1",1.0f);
				//Application.LoadLevel("Stage1");
			}

			if(textLine == 2)
			{
				Debug.Log("Ok");
			}
		}

		if(currentNum < useText.Count())
		{
			//　storageに対してusetextから一文字を追加する
			storage += useText[currentNum];
			if( insertNum >= 23 ) 
			{
				if(currentNum + 1 < useText.Count())
				{
					if(useText[currentNum + 1] != '。' || useText[currentNum + 1] != '！' || 
					   useText[currentNum + 1] != '？' || useText[currentNum + 1] != '、')
					{
						storage += '\n';
					}
				}

				insertNum = 0;
			}
			
			//　次の文字を追加するための準備
			currentNum++;
			insertNum++;

		}
	}

	/*
	void DrawTextBox()
	{
		if(Hide)
		{
			GUI.Label(new Rect(0,0,640,100),TextBox);
		}


	}
	*/
}
