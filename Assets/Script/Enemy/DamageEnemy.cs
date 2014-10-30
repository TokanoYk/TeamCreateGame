using UnityEngine;
using System.Collections;

//	Enemyが死ぬ用
public class DamageEnemy : MonoBehaviour {
	
	//	死んだ時に呼びだされるパーティクル
	public GameObject DeathParticle; 

	//	-------------------------------------------
	//	GetComponent用
	//	-------------------------------------------
	public GameObject PlayerObject;
	private ActionPlayer _player;

	//	-------------------------------------------
	//	ステータス
	//	-------------------------------------------
	//	体力
	private int Life = 1;
	public int enemyAttackPower = 1;

	//	死んでいるかどうか
	//private bool dead = false;

	// Use this for initialization
	void Start () {
		_player = PlayerObject.GetComponent<ActionPlayer> ();
		Life = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	/// <summary>敵がダメージを受けるときに呼び出される</summary>
	//	自分で消すのが問題ありなので別で消す
	public void OnWormDamage(int _damage,bool dead)
	{
		wormHp -= _damage;

		if(wormHp <= 0)
		{
			//	体力がなくなったらdeadをtrueにする
			Debug.Log("death");
			dead = true;
		}
	}*/

	/// <summary>ぶつかった</summary>
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Attack" || coll.gameObject.tag == "Player")
		{
			Life -= _player.attackPower;
			Destroy(gameObject);
			Dead ();
		}
	}
	/// <summary>パーティクルを発生させる関数</summary>
	void DrawParticle()
	{
		//	Particleの発生
		GameObject instant_object = (GameObject)GameObject.Instantiate(DeathParticle,new Vector3(transform.position.x,transform.position.y,transform.position.z - 2), Quaternion.identity);
		//	Particleの消去
		GameObject.Destroy(instant_object,1);
	}

	/// <summary>プレイヤーが死んだ時の関数</summary>
	void Dead()
	{
		if(Life <= 0)
		{
			DrawParticle();
			Destroy(gameObject);
		}
	}

}
