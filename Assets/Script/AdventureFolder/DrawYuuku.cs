using UnityEngine;
using System.Collections;

public class DrawYuuku: MonoBehaviour {

	//	宣言
	SpriteRenderer YuukuSprite;

	//	--------------------------------------------
	//	表情
	//	--------------------------------------------
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
	/// <summary>消える</summary>
	public Sprite YuukuHide;

	//	半透明影（話していない時）？


	//	-------------------------------------------
	//	判定
	//	-------------------------------------------
	/// <summary>グラタンのとき</summary>
	public bool gratan = false;
	/// <summary>泣き</summary>
	public bool cry = false;
	/// <summary>疑問</summary>
	public bool question = false;
	/// <summary>驚き</summary>
	public bool impatience = false;
	/// <summary>笑顔</summary>
	public bool smile = false;
	/// <summary>悔しい</summary>
	public bool mortifying = false;
	/// <summary>落ち込み</summary>
	public bool drop = false;
	/// <summary>呆れ</summary>
	public bool amazed = false;
	/// <summary>消える</summary>
	public bool hide = false;

	// Use this for initialization
	void Start () {
		YuukuSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		DrawingYuuku ();
	}

	void DrawingYuuku()
	{
		if (gratan)
			YuukuSprite.sprite = YuukuGratan;
		if (cry)
			YuukuSprite.sprite = YuukuCry;
		if (question)
			YuukuSprite.sprite = YuukuQuestion;
		if (impatience)
			YuukuSprite.sprite = YuukuImpatience;
		if (smile)
			YuukuSprite.sprite = YuukuSmile;
		if (mortifying)
			YuukuSprite.sprite = YuukuMortifying;
		if (drop)
			YuukuSprite.sprite = YuukuDrop;
		if (amazed)
			YuukuSprite.sprite = YuukuAmazed;
		if (hide)
			YuukuSprite.sprite = YuukuHide;
	}
}
