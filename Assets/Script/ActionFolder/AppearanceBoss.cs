using UnityEngine;
using System.Collections;

//	ボスが登場するスクリプト
public class AppearanceBoss : MonoBehaviour {
	
	private StageMove _stageMove;
	public GameObject StageObject;


	//private float appearanceMove = 5.0f;

	// Use this for initialization
	void Start () {
		_stageMove = StageObject.GetComponent<StageMove>(); 
		//	生成された時にアニメーションを再生させない
		//gameObject.animation.Stop("BossAnimation");
	}
	
	// Update is called once per frame
	void Update () {
	
		Appearance ();
	}

	void Appearance()
	{
		gameObject.animation.Stop("BossAnimation");
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(_stageMove.StageStop)
		{
			//rigidbody2D.velocity = new Vector2 (-appearanceMove, 0);
		}
		//	登場する場所まで移動したら戦闘が開始する
		if(coll.gameObject.tag == "AppearanceZone")
		{
			//rigidbody2D.velocity = new Vector2 (76f, 1f);
		}
	}
}
