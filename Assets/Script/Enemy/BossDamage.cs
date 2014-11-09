﻿using UnityEngine;
using System.Collections;

//	ボス関係
public class BossDamage : MonoBehaviour {

	//	-------------------------------------------
	//	ゲームオブジェクトの指定
	//	-------------------------------------------
	//	パーティクルの指定
	//public GameObject DeathParticle; 

	//	-------------------------------------------
	//	GetComponent用
	//	-------------------------------------------
	public GameObject Player;
	private ActionPlayer _player;
	//	点滅処理のレンダー
	private SpriteRenderer _renderer;
	
	//	-------------------------------------------
	//	判定用
	//	-------------------------------------------

	public bool damageFlag = false;
	public bool battleFinish = false;

	//	-------------------------------------------
	//	ステータス
	//	-------------------------------------------
	[SerializeField]
	//	体力
	public int Life = 10;
	//	攻撃力
	public int AttackPower = 1;


	// Use this for initialization
	void Start () {
		_player = Player.GetComponent<ActionPlayer> ();
		_renderer = gameObject.GetComponent<SpriteRenderer> ();
		Life = 10;
	}
	
	// Update is called once per frame
	void Update () {
		Flashing ();
	}

	/// <summary>攻撃とかぶつかった</summary>
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Attack" )
		{
			//	ダメージフラグをtrueにする.
			damageFlag = true;
			Life -= _player.attackPower;
			// コルーチン開始
			StartCoroutine("WaitForIt");

			Dead ();
		}
	}

	/*
	/// <summary>パーティクルを発生させる関数</summary>
	void DrawParticle()
	{
		//	Particleの発生
		GameObject instant_object = (GameObject)GameObject.Instantiate(DeathParticle,new Vector3(transform.position.x,transform.position.y,transform.position.z - 2), Quaternion.identity);
		//	Particleの消去
		GameObject.Destroy(instant_object,1);
	}
	*/

	/// <summary>攻撃を食らった時に点滅する</summary>
	void Flashing()
	{
		if(damageFlag)
		{
			float level = Mathf.Abs(Mathf.Sin (Time.time * 10));
			_renderer.color = new Color(256f,0f,0f,level);
		}
	}
	
	IEnumerator WaitForIt()
	{
		//	１秒間処理を止める
		yield return new WaitForSeconds (0.5f);
		
		
		//	１秒間無敵になってる？
		//	１秒後ダメージフラグをfalseにして点滅を戻す
		damageFlag = false;
		_renderer.color = new Color (1f, 1f, 1f, 1f);
	}


	/// <summary>プレイヤーが死んだ時の関数</summary>
	void Dead()
	{
		if(Life <= 0)
		{
			//Destroy(gameObject);
			//DrawParticle();
			battleFinish = true;
			GetComponent<Animator>().SetBool("BattleFinish",battleFinish);
		}
	}
}
