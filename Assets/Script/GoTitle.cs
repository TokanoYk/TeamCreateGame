using UnityEngine;
using System.Collections;

//	ゲームオーバー画面
public class GoTitle: MonoBehaviour {

	public AudioClip book;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Return))
		{
			audio.PlayOneShot(book);
			FadeManager.Instance.LoadLevel("Title",1.0f);
		}
	}

}
