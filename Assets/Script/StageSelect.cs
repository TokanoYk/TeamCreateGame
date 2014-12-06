using UnityEngine;
using System.Collections;

public class StageSelect : MonoBehaviour {

	//	シナリオタイトルのテクスチャ
	public Texture2D ScenarioTitle;
	//	カーソル
	public Texture2D Cursor;

	//	合わせているステージ
	int Stage = 0;

	//　エンターが押された
	bool OnKey = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Select ();
	}

	void Select()
	{
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			Stage ++;

			if(Stage > 2)
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
				Stage = 2;
			}
			Debug.Log(Stage);
		}

		if(Input.GetKeyDown(KeyCode.Return))
		{
			if(Stage == 0)
			{
				FadeManager.Instance.LoadLevel("NovelPart", 1.0f);
				OnKey = true;
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

	void OnGUI()
	{
		float sw = Screen.width;
		float sh = Screen.height;

		if(!OnKey)
		{
			//	１
			GUI.Label (new Rect (sw / 2 - 180 , sh / 2 - 150, 300, 100), ScenarioTitle);
			//	２
			GUI.Label (new Rect (sw / 2 - 180 , sh / 2 - 30  , 300, 100), ScenarioTitle);
			//	３
			GUI.Label (new Rect (sw / 2 - 180 , sh / 2 + 90 , 300, 100), ScenarioTitle);

			if(Stage == 0)
			{
				GUI.Label (new Rect (sw / 2 - 250 , sh / 2 - 140, 50, 50), Cursor);
			}
			if(Stage == 1)
			{
				GUI.Label (new Rect (sw / 2 - 250 , sh / 2 - 20, 50, 50), Cursor);
			}
			if(Stage == 2)
			{
				GUI.Label (new Rect (sw / 2 - 250 , sh / 2  + 110, 50, 50), Cursor);
			}
		}
	}
	/*
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Stage1")
        {
            FadeManager.Instance.LoadLevel("Stage1", 1.0f);
        }
    }
	*/
}
