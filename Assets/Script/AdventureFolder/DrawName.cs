using UnityEngine;
using System.Collections;

public class DrawName : MonoBehaviour {
	//	宣言
	SpriteRenderer NameBoxSprite;
	
	//	--------------------------------------------
	//	名前
	//	--------------------------------------------
	public Sprite YuukuNameBox;
	public Sprite NeneaNameBox;
	public Sprite MiriaNameBox;
	public Sprite NazoNameBox;
	public Sprite HideNameBox;
	
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
	
	
	// Use this for initialization
	void Start () {
		NameBoxSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		DrawingNenea ();
	}
	
	void DrawingNenea()
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
}
