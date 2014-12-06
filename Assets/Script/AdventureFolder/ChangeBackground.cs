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
	//	判定
	//	---------------------------------------------------
	public bool home = true;
	public bool forest = false;


	// Use this for initialization
	void Start () {
		BackgroundSprite = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		DrawingBackground ();
	}

	void DrawingBackground()
	{
		if (home)
			BackgroundSprite.sprite = YuukuHomeGraphic;
		if (forest)
			BackgroundSprite.sprite = ForestGraphic;
	}
}
