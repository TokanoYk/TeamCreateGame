using UnityEngine;
using System.Collections;

public class P_Damage : MonoBehaviour {

	private Attack _player;
	public GameObject Player;

	//	いつか敵の攻撃Manager作る
	private DamageEnemy _enemy;
	public GameObject WormObject;

	private DeathManager _deathManager;
	public GameObject DeadManagerObject;

	//	攻撃力
	//private int attackPower = 1;



	// Use this for initialization
	void Start () {
		//_player = Player.GetComponent<Attack> ();
		//_enemy = WormObject.GetComponent<DamageEnemy> ();
		//_deathManager = DeadManagerObject.GetComponent<DeathManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	/// <summary>ダメージを敵にあたえる関数</summary>
	public void OnAttack (int _damage)
	{
		/*
		//_worm.OnWormDamage (attackPower,false);
		if(_worm.dead)
		{
			_deathManager.DeathWorm();
		}
		*/
	}
	/*
	// 現状:プレイヤーと攻撃オブジェクトが一緒に判定されていると呼びだされる模様？？？
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Enemy")
		{
			OnAttack(attackPower);
			//OnAttack(attackPower);
			Debug.Log("Hit");
		}
	}*/

}
