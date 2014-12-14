using UnityEngine;
using System.Collections;

public class UIAnimation : MonoBehaviour {
	
	//	取得
	private Title _title;
	public GameObject UIManage;

	bool start = true;
	bool exit = false;

	bool enter = false;

	// Use this for initialization
	void Start () {
		_title = UIManage.GetComponent<Title> ();
	}
	
	// Update is called once per frame
	void Update () {
		DrawAnimation ();
	}

	void DrawAnimation()
	{
		//	-----------------------------------------------------
		//	タイトル
		//	-----------------------------------------------------
		if(_title.SelectNumber == 0)
		{
			//	Start
			start = true;
			exit = false;
			//	Startに変数を送る
			GetComponent<Animator>().SetBool("StartOn",start);
			//	Exitに変数を送る
			GetComponent<Animator>().SetBool("ExitOn",exit);

			//	エンターが押されたら
			PushEnter();
		}
		else
		{
			exit = true;
			start = false;
			//	Exitに変数を送る
			GetComponent<Animator>().SetBool("ExitOn",exit);
			//	Startに変数を送る
			GetComponent<Animator>().SetBool("StartOn",start);

			PushEnter();
		}
	}

	void PushEnter()
	{
		if(_title.OnKey)
		{
			enter = true;
			GetComponent<Animator>().SetBool("Enter",enter);
		}
	}
}
