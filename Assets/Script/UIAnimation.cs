using UnityEngine;
using System.Collections;

public class UIAnimation : MonoBehaviour {

	//	取得
	private Title _cursor;
	public GameObject UIManage;

	bool start = true;
	bool exit = false;

	// Use this for initialization
	void Start () {
		_cursor = UIManage.GetComponent<Title> ();
	}
	
	// Update is called once per frame
	void Update () {
		DrawAnimation ();
	}

	void DrawAnimation()
	{
		if(_cursor.SelectNumber == 0)
		{
			//	Start
			start = true;
			exit = false;
		}
		else
		{
			exit = true;
			start = false;
		}

		if(start || exit)
		{
			GetComponent<Animator>().SetBool("StartOn",start);
			GetComponent<Animator>().SetBool("ExitOn",exit);
		}
	}
}
