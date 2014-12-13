using UnityEngine;
using System.Collections;


//	ネネアが蛾に襲われたら呼び出す
public class ChangeBGM : MonoBehaviour {

	private NovelPatt _novel;
	public GameObject TextObject;

	//	サウンド
	public AudioClip PeacefulBGM;
	public AudioClip Suddenly;

	public bool one = false;

	// Use this for initialization
	void Start () {
		_novel = TextObject.GetComponent<NovelPatt> ();

		audio.PlayOneShot(PeacefulBGM);	
	}
	
	// Update is called once per frame
	void Update () {
		Change ();
	}

	void Change()
	{
		//	テキストマネージャーから変数を取って再生を変更
		if(_novel.play)
		{
			if(!one)
			{
					one = true;

					audio.Stop();
					audio.PlayOneShot(Suddenly);
			}
		}
	}

}
