using UnityEngine;
using System.Collections;

public class DrawNenea : MonoBehaviour {
	
	//	宣言
	SpriteRenderer NeneaSprite;


	//	--------------------------------------------
	//	表情
	//	--------------------------------------------
	/// <summary>無視（ツーン！）</summary>
	public Sprite NeneaNeglect;
	/// <summary>泣き</summary>
	public Sprite NeneaCry;
	/// <summary>「助けてお兄ちゃん！」</summary>
	public Sprite NeneaHelp;
	/// <summary>笑顔</summary>
	public Sprite NeneaSmile;
	/// <summary>嬉しい</summary>
	public Sprite NeneaHappy;
	/// <summary>消える</summary>
	public Sprite NeneaHide;

	//	半透明影（話していない時）？
	
	//	-------------------------------------------
	//	判定
	//	-------------------------------------------
	/// <summary>無視</summary>
	public bool neglect = false;
	/// <summary>泣き</summary>
	public bool cry = false;
	/// <summary>助けて</summary>
	public bool help = false;
	/// <summary>笑顔</summary>
	public bool smile = false;
	/// <summary>笑顔その２</summary>
	public bool happy = false;
	/// <summary>消える</summary>
	public bool hide = false;

	public bool moveOn = false;

	// Use this for initialization
	void Start () {
		NeneaSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		DrawingNenea ();
		Move ();
	}
	
	void DrawingNenea()
	{
		if (neglect)
			NeneaSprite.sprite = NeneaNeglect;
		if (cry)
			NeneaSprite.sprite = NeneaCry;
		if (help)
			NeneaSprite.sprite = NeneaHelp;
		if (smile)
			NeneaSprite.sprite = NeneaSmile;
		if (happy)
			NeneaSprite.sprite = NeneaHappy;
		if (hide)
			NeneaSprite.sprite = NeneaHide;
	}

	//	襲われた時に-2.5に移動する

	void Move()
	{
		Vector2 NewPosition = transform.position;

		if(moveOn)
		{
			NewPosition.x = -2.5f;
		}

		transform.position = NewPosition;
	}
}
