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

	public GameObject WordAnimationObject;
	private WordAnimation _wordanimation;

	public GameObject WordObject;
	private DrawWordsCounter _words;

	//	-------------------------------------------
	//	ステータス
	//	-------------------------------------------
	//	体力
	private int Life = 1;
	public int enemyAttackPower = 30;

	private float FlySpeed = 20f;
	private float Fly = 10f;
	private float y = 0.0f;

	private float rotateX = 0f;
	private float rotateY = 0f;
	private float rotateZ = -30f;

	//	死んでいるかどうか
	public bool dead = false;

	// Use this for initialization
	void Start () {
		_player = PlayerObject.GetComponent<ActionPlayer> ();
		_words = WordObject.GetComponent<DrawWordsCounter> ();
		_wordanimation = WordAnimationObject.GetComponent<WordAnimation> ();

		Life = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Life <= 0)
		{
			Turn();
		}
	}

	/// <summary>ぶつかった</summary>
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Attack" || coll.gameObject.tag == "Player")
		{
			_words.words ++;
			Life -= _player.attackPower;
			//Destroy(gameObject);
			Dead ();
		}
	}
	/// <summary>パーティクルを発生させる関数</summary>
	void DrawParticle()
	{
		_wordanimation.off = false;

		//	Particleの発生
		GameObject instant_object = (GameObject)GameObject.Instantiate(DeathParticle,new Vector3(transform.position.x,transform.position.y,transform.position.z - 2), Quaternion.identity);
		//	Particleの消去
		GameObject.Destroy(instant_object,1);
	}

	/// <summary>プレイヤーが死んだ時の関数</summary>
	void Dead()
	{
		//	場所を格納
		Vector2 NewPosition = transform.position ;

		if(Life <= 0)
		{
			//	斜め上へ
			rigidbody2D.velocity = new Vector2 (FlySpeed, y += Fly);

			//	敵グラが消えた瞬間にParticle発生
			Invoke("DrawParticle",0.3f);
			Destroy(gameObject,0.3f);
		}
		//	場所の上書き
		transform.position = NewPosition;
	}

	void Turn()
	{
		//	敵が死んだ時にまわる
		rigidbody2D.transform.Rotate(rotateX,rotateY,rotateZ);
	}
}
