using UnityEngine;
using System.Collections;

//	テキストマネージャーからテキストに問い合わせたデータパスを受け取って
//	表情を変化させる
public class CharaManage : MonoBehaviour {

	//	http://qiita.com/2dgames_jp/items/ed79779893a69cfc17aa

	SpriteRenderer drawSprite;

	//	誰のデータなのか判断
	public GameObject textObject;
	private textManager _text;

	//	キャラの名前データを保持
	public string charaName;

	/// <summary>グラタンのとき</summary>
	public Sprite YuukuGratan;
	/// <summary>泣き</summary>
	public Sprite YuukuCry;
	/// <summary>疑問</summary>
	public Sprite YuukuQuestion;
	/// <summary>驚き</summary>
	public Sprite YuukuImpatience;
	/// <summary>笑顔</summary>
	public Sprite YuukuSmile;
	/// <summary>悔しい</summary>
	public Sprite YuukuMortifying;
	/// <summary>落ち込み</summary>
	public Sprite YuukuDrop;
	/// <summary>呆れ</summary>
	public Sprite YuukuAmazed;



	// Use this for initialization
	void Start () {
		_text = textObject.GetComponent<textManager> ();
		drawSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		CharaSeting ();
	}

	/// <summary></summary>
	void CharaSeting()
	{
		Debug.Log (_text.characterName);

		if(_text.characterName == charaName)
		{
			characterDraw();
		}
	}

	/// <summary>キャラクターのグラフィックをtextManagerから取得して表示する</summary>
	void characterDraw()
	{

		Debug.Log (_text.textureId);

		//	ユーク
		switch(_text.textureId)
		{
		case "y1":
			drawSprite.sprite = YuukuSmile;
			break;

		}

	}

}
