using UnityEngine;
using System.Collections;

//	Escを押すとゲーム終了
public class ExitGame : MonoBehaviour {

	public AudioClip bookclose;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			audio.PlayOneShot(bookclose);
			Invoke("Close",0.8f);
		}
	}

	void Close()
	{
		Application.Quit();
	}
}
