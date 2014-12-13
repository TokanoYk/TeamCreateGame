using UnityEngine;
using System.Collections;

//	ボス戦に入ったら音楽を切り替える
public class BossSound : MonoBehaviour {

	public AudioClip BossBattleMusic;
	public AudioClip ActionMusic;

	//	福重防止
	private bool one = false;

	// Use this for initialization
	void Start () {
		//audio.PlayOneShot(ActionMusic);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//	生成ゾーンにあたったらサウンドを切り替える
		if(coll.gameObject.tag == "Player")
		{
			if(!one)
			{
				one = true;
				//	音楽を変える
				audio.Stop();
				audio.PlayOneShot(BossBattleMusic);
			}
		}
	}

}
