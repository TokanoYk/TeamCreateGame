using UnityEngine;
using System.Collections;

//	テキストマネージャーからテキストに問い合わせたデータパスを受け取って
//	表情を変化させる
public class CharaManage : MonoBehaviour {

	//	スプライトの宣言
	SpriteRenderer drawSprite;

	//	誰のデータなのか判断
	public GameObject textObject;
	private textManager _text;

	//	キャラの名前データを保持
	public string charaName;
	public string hide = "hide";

	public Sprite chara1;
	public Sprite chara2;
	public Sprite chara3;
	public Sprite chara4;
	public Sprite chara5;
	public Sprite chara6;
	public Sprite chara7;
	public Sprite chara8;

	private Sprite charaHide;
	
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
		else if(_text.characterName == hide)
		{
			drawSprite.sprite = charaHide;
		}
	}

	/// <summary>キャラクターのグラフィックをtextManagerから取得して表示する</summary>
	void characterDraw()
	{
		switch(_text.textureId)
		{
			case "y1":
				drawSprite.sprite = chara1;
				break;
			case "y2":
				drawSprite.sprite = chara2;
				break;
			case "y3":
				drawSprite.sprite = chara3;
				break;
			case "y4":
				drawSprite.sprite = chara4;
				break;
			case "y5":
				drawSprite.sprite = chara5;
				break;
			case "y6":
				drawSprite.sprite = chara6;
				break;
			case "y7":
				drawSprite.sprite = chara7;
				break;
			case "y8":
				drawSprite.sprite = chara8;
				break;

			//	---------------------------------

			case "m1":
				drawSprite.sprite = chara1;
				break;
			case "m2":
				drawSprite.sprite = chara2;
				break;	
			case "m3":
				drawSprite.sprite = chara3;
				break;
			case "m4":
				drawSprite.sprite = chara4;
				break;
			case "m5":
				drawSprite.sprite = chara5;
				break;
			case "m6":
				drawSprite.sprite = chara6;
				break;
			case "m7":
				drawSprite.sprite = chara7;
				break;
			case "m8":
				drawSprite.sprite = chara8;
				break;

			//	--------------------------------

			case "n1":
				drawSprite.sprite = chara1;
				break;
			case "n2":
				drawSprite.sprite = chara2;
				break;
			case "n3":
				drawSprite.sprite = chara3;
				break;
			case "n4":
				drawSprite.sprite = chara4;
				break;
			case "n5":
				drawSprite.sprite = chara5;
				break;
			case "n6":
				drawSprite.sprite = chara6;
				break;
		}
	}

}
