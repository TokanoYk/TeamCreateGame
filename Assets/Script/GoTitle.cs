using UnityEngine;
using System.Collections;

//	ゲームオーバー画面
public class GoTitle: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Return))
		{
			FadeManager.Instance.LoadLevel("Title",1.0f);
		}
	}

}
