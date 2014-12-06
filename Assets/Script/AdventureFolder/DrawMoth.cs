using UnityEngine;
using System.Collections;

public class DrawMoth : MonoBehaviour {

	//	宣言
	SpriteRenderer MothSprite;
	
	//	--------------------------------------------
	//	表情
	//	--------------------------------------------
	/// <summary>蛾</summary>
	public Sprite Moth;
	/// <summary>非表示</summary>
	public Sprite MothHide;
	
	//	半透明影（話していない時）？
	
	//	-------------------------------------------
	//	判定
	//	-------------------------------------------
	/// <summary>無視</summary>
	public bool draw = false;
	/// <summary>消える</summary>
	public bool hide = false;
	
	
	// Use this for initialization
	void Start () {
		MothSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		DrawingMoth ();
	}
	
	void DrawingMoth()
	{
		if (draw)
			MothSprite.sprite = Moth;
		if (hide)
			MothSprite.sprite = MothHide;
	}
}
