using UnityEngine;
using System.Collections;

public class ChangeBackground : MonoBehaviour {

	//	宣言
	SpriteRenderer BackgroundSprite;

	//	---------------------------------------------------
	//	背景の指定
	//	---------------------------------------------------
	public Sprite YuukuHomeGraphic;
	public Sprite ForestGraphic;

	//	---------------------------------------------------
	//	取得
	//	---------------------------------------------------
	private textManager _text;
	public GameObject textObject;

	//	---------------------------------------------------
	//	判定
	//	---------------------------------------------------
	/*
	public bool home = true;
	public bool forest = false;
	*/

	// Use this for initialization
	void Start () {
		_text = textObject.GetComponent<textManager> ();
		BackgroundSprite = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		DrawingBackground ();
	}

	void DrawingBackground()
	{
		/*
		if (home)
			BackgroundSprite.sprite = YuukuHomeGraphic;
		if (forest)
			BackgroundSprite.sprite = ForestGraphic;
		*/

		if(_text.backgroundName == "home")
			BackgroundSprite.sprite = YuukuHomeGraphic;

		if(_text.backgroundName == "forest")
			BackgroundSprite.sprite = ForestGraphic;

	}
}
