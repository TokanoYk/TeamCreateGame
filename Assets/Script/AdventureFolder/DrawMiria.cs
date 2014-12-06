using UnityEngine;
using System.Collections;

public class DrawMiria : MonoBehaviour {
	
	//	宣言
	SpriteRenderer MiriaSprite;
	
	//	--------------------------------------------
	//	表情
	//	--------------------------------------------
	/// <summary>哀しみ</summary>
	public Sprite MiriaCry;
	/// <summary>真剣</summary>
	public Sprite MiriaEarnest;
	/// <summary>焦り</summary>
	public Sprite MiriaImpatience;
	/// <summary>笑顔</summary>
	public Sprite MiriaSmile;
	/// <summary>真剣（口開き）</summary>
	public Sprite MiriaErinest2;
	/// <summary>懇願</summary>
	public Sprite MiriaAppeal;
	/// <summary>影</summary>
	public Sprite MiriaShadow;
	/// <summary>消える</summary>
	public Sprite MiriaHide;	

	//	半透明影（話していない時）？

	//	-------------------------------------------
	//	判定
	//	-------------------------------------------
	/// <summary>哀しみ</summary>
	public bool cry = false;
	/// <summary>真剣</summary>
	public bool earnest = false;
	/// <summary>焦り</summary>
	public bool impatience = false;
	/// <summary>笑顔</summary>
	public bool smile = false;
	/// <summary>真剣（口開き）</summary>
	public bool erinest2 = false;
	/// <summary>懇願</summary>
	public bool appeal = false;
	/// <summary>影</summary>
	public bool shadow = false;
	/// <summary>消える</summary>
	public bool hide = false;

	// Use this for initialization
	void Start () {
		MiriaSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		DrawingMiria ();
	}
	
	void DrawingMiria()
	{
		if (cry)
			MiriaSprite.sprite = MiriaCry;
		if (earnest)
			MiriaSprite.sprite = MiriaEarnest;
		if (impatience)
			MiriaSprite.sprite = MiriaImpatience;
		if (smile)
			MiriaSprite.sprite = MiriaSmile;
		if (erinest2)
			MiriaSprite.sprite = MiriaErinest2;
		if (appeal)
			MiriaSprite.sprite = MiriaAppeal;
		if (shadow)
			MiriaSprite.sprite = MiriaShadow;
		if (hide)
			MiriaSprite.sprite = MiriaHide;
	}
}
