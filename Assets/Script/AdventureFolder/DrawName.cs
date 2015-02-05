using UnityEngine;
using System.Collections;

public class DrawName : MonoBehaviour {

	//	宣言
	//SpriteRenderer NameBoxSprite;
	SpriteRenderer nameSprite;

	//	テキストマネージャーの情報
	public GameObject textObject;
	private textManager _text;

	//	--------------------------------------------
	//	名前
	//	--------------------------------------------
	public Sprite YuukuNameBox;
	public Sprite NeneaNameBox;
	public Sprite MiriaNameBox;
	public Sprite NazoNameBox;
	public Sprite HideNameBox;
	
	/*
	//	-------------------------------------------
	//	判定
	//	-------------------------------------------
	/// <summary>ユーク</summary>
	public bool yuukuName = false;
	/// <summary>ネネア</summary>
	public bool neneaName = false;
	/// <summary>ミリア</summary>
	public bool miriaName = false;
	/// <summary>名前「？？？」</summary>
	public bool nazo = false;
	/// <summary>非表示</summary>
	public bool hide = false;
	*/
	
	// Use this for initialization
	void Start ()
	{
		_text = textObject.GetComponent<textManager> ();
		//NameBoxSprite = gameObject.GetComponent<SpriteRenderer>();
		nameSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		nameDraw ();
		//DrawingName ();
	}

	/// <summary>ネームボックスの表示</summary>
	void nameDraw()
	{
		if(_text.characterName == "yuuku")
			nameSprite.sprite = YuukuNameBox;
		if(_text.characterName == "nenea")
			nameSprite.sprite = NeneaNameBox;
		if (_text.characterName == "miria")
			nameSprite.sprite = MiriaNameBox;
		//	例外時
		if (_text.textureId == "m7")
			nameSprite.sprite = NazoNameBox;
		if (_text.textureId == "n7" || _text.characterName == "hide")
			nameSprite.sprite = HideNameBox;
	}

	/*
	void DrawingName()
	{
		if (yuukuName)
			NameBoxSprite.sprite = YuukuNameBox;
		if (neneaName)
			NameBoxSprite.sprite = NeneaNameBox;
		if (miriaName)
			NameBoxSprite.sprite = MiriaNameBox;
		if (nazo)
			NameBoxSprite.sprite = NazoNameBox;
		if (hide)
			NameBoxSprite.sprite = HideNameBox;
	}
	 */
}
