using UnityEngine;
using System.Collections;

public class StageSelect : MonoBehaviour {

	//	宣言
	SpriteRenderer ChapterBack;

	//	サウンド
	public AudioClip Page;

	/*
	//	シナリオタイトルのテクスチャ
	public Texture2D ScenarioTitleRed;
	public Texture2D ScenarioTitleBlue;
	public Texture2D ScenarioTitleGreen;

	//	カーソル
	public Texture2D Cursor;
	*/

	//	表示している章ごとにキャラクターの画像を表示する
	public Sprite ChapterOne;
	public Sprite ChapterTwo;


	//	合わせているステージ
	public int Stage = 0;

	//　エンターが押された
	public bool OnEnter = false;

	// Use this for initialization
	void Start () {
		ChapterBack = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Select ();
		DrawingBackground ();
	}

	void Select()
	{
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			Stage ++;

			if(Stage > 1)
			{
				Stage = 0;
			}

			Debug.Log(Stage);
		}

		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			Stage --;
			if(Stage < 0)
			{
				Stage = 1;
			}
			Debug.Log(Stage);
		}

		if(Input.GetKeyDown(KeyCode.Return))
		{
			if(Stage == 0)
			{
				audio.PlayOneShot(Page);
				FadeManager.Instance.LoadLevel("Word", 2.0f);
				OnEnter = true;
			}
			/*
			if(Stage == 1)
			{
				//FadeManager.Instance.LoadLevel("NovelPart", 1.0f);
			}

			if(Stage == 2)
			{
				//FadeManager.Instance.LoadLevel("NovelPart", 1.0f);
			}
			*/

		}
	}
/*
	void OnGUI()
	{
		float sw = Screen.width;
		float sh = Screen.height;

		if(!OnKey)
		{

			//	１
			GUI.Label (new Rect (sw / 2 - 170 , sh / 2 - 60, 340, 100), ScenarioTitleRed);
			//	２
			GUI.Label (new Rect (sw / 2 - 170 , sh / 2 + 30, 340, 100), ScenarioTitleBlue);
			//	３
			GUI.Label (new Rect (sw / 2 - 170 , sh / 2 + 120, 340, 100), ScenarioTitleGreen);

			if(Stage == 0)
			{
				GUI.Label (new Rect (sw / 2 - 230 , sh / 2 - 50, 50, 50), Cursor);
			}
			if(Stage == 1)
			{
				GUI.Label (new Rect (sw / 2 - 230 , sh / 2 + 50, 50, 50), Cursor);
			}
			if(Stage == 2)
			{
				GUI.Label (new Rect (sw / 2 - 230 , sh / 2  + 135, 50, 50), Cursor);
			}
		}
	}
*/
	void DrawingBackground()
	{
		if (Stage == 0)
			ChapterBack.sprite = ChapterOne;
		if (Stage == 1)
			ChapterBack.sprite = ChapterTwo;
	}

}
