using UnityEngine;
using System.Collections;

public class SelectUIAnimation : MonoBehaviour {

	private StageSelect _select;
	public GameObject SelectObject;
	
	bool redStart = false;
	bool redEnter = false;

	bool blueStart = false;
	//bool blueEnter = false;

	//bool greenStart = false;
	//bool greenEnter = false;

	// Use this for initialization
	void Start () {
		_select = SelectObject.GetComponent<StageSelect> ();
	}
	
	// Update is called once per frame
	void Update () {
		DrawAnimation ();
	}

	void DrawAnimation()
	{
		if(_select.Stage == 0)
		{
			//	赤い栞を左にずらす
			redStart = true;
			GetComponent<Animator>().SetBool("RedStart",redStart);

			//	青と緑はBackかStop
			//	緑だったら緑がBack、青だったら青がBackの処理
			if(blueStart)
			{	
				blueStart = false;
				GetComponent<Animator>().SetBool("BlueStart",blueStart);
			}
			/*
			if(greenStart)
			{
				greenStart = false;
				GetComponent<Animator>().SetBool("GreenStart",greenStart);
			}*/

			PushEnter();
		}

		if(_select.Stage == 1)
		{
			//	青い栞を左にずらす
			blueStart = true;
			GetComponent<Animator>().SetBool("BlueStart",blueStart);

			//	赤と緑はBackはStop
			//	赤だったら赤Back、青～
			if(redStart)
			{
				redStart = false;
				GetComponent<Animator>().SetBool("RedStart",redStart);
			}
			/*if(greenStart)
			{
				greenStart = false;
				GetComponent<Animator>().SetBool("GreenStart",greenStart);
			}*/

			PushEnter();
		}
		/*
		if(_select.Stage == 2)
		{
			//	緑の栞を左にずらす
			greenStart = true;
			GetComponent<Animator>().SetBool("GreenStart",greenStart);

			//	赤と青はBackかStop
			//	赤だったら～
			if(redStart)
			{
				redStart = false;
				GetComponent<Animator>().SetBool("RedStart",redStart);
			}
			if(blueStart)
			{
				blueStart = false;
				GetComponent<Animator>().SetBool("BlueStart",blueStart);
			}

			PushEnter();
		}
		*/
	}

	void PushEnter()
	{
		if(_select.OnEnter)
		{
			if(redStart)
			{
				redEnter = true;
				//	アニメーション
				GetComponent<Animator>().SetBool("RedEnter",redEnter);
			}
		}

		//	青。緑ともに未実装
	}

}
