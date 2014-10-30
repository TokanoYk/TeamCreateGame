using UnityEngine;
using System.Collections;

public class BossAttackLaunch : MonoBehaviour {

	//	-------------------------------------------
	//	ステータス
	//	-------------------------------------------
	//	球のスピード
	private float bulletSpeed = 6f;

	//	斜め打ち用
	private float y = 0.0f;
	private float fallSpead1 = 0.03f;


	//private BossAttack _bossAttack;
	//public GameObject bossAttackObject;

	public bool bullet1, bullet2, bullet3 = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Launch ();
	}

	/// <summary>ぶつかった</summary>
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
	
	/// <summary>弾を移動させる関数</summary>
	void Launch()
	{
		//	場所を格納
		Vector2 NewPosition = transform.position ;

		if(bullet1)
		{
			rigidbody2D.velocity = new Vector2 (-bulletSpeed, 0f);
		}

		if(bullet2)
		{
			rigidbody2D.velocity = new Vector2 (-bulletSpeed, y -= fallSpead1);
		}

		if(bullet3)
		{
			rigidbody2D.velocity = new Vector2 (-bulletSpeed, y -= 0.07f);
		}
		//	場所の上書き
		transform.position = NewPosition;
	}

}
