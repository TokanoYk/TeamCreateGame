using UnityEngine;
using System.Collections;

//	ボスが登場するスクリプト
public class AppearanceBoss : MonoBehaviour {


	//	------------------------------------------------
	//	GetComponent用
	//	------------------------------------------------
	private StageMove _stageMove;
	public GameObject StageObject;

	//	------------------------------------------------
	//	判定用
	//	------------------------------------------------
	public bool BossMove = false;
	public bool AttackStart = false;

	//	------------------------------------------------
	//	アニメーション用
	//	------------------------------------------------
	private bool BossAttackAnimationStart = false;
	private bool BossMoveAnimation = false;


	// Use this for initialization
	void Start () {
		_stageMove = StageObject.GetComponent<StageMove>(); 
	}
	
	// Update is called once per frame
	void Update () {
		BossMoveAnimatonStart ();
	}

	/// <summary>ボスが右からフェードインしてくるアニメーションの再生</summary>
	void BossMoveAnimatonStart()
	{
		if(_stageMove.StageStop)
		{
			//	アニメ＾ションの判定
			BossMove = true;
			if(BossMove)
			{
				//	アニメ＾ションの判定
				BossMoveAnimation = true;
				//	ボス移動のアニメーションを再生
				GetComponent<Animator>().SetBool("Move",BossMoveAnimation);
			}
		}
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		//	登場する場所まで移動したら戦闘が開始する
		if(coll.gameObject.tag == "AppearanceZone")
		{
			//	アニメーションの判定
			BossAttackAnimationStart = true;
			//	先頭アニメーションの再生
			GetComponent<Animator>().SetBool("SetAttack",BossAttackAnimationStart);
			//	ボスの攻撃開始の判定
			AttackStart = true;
		}
	}
}
