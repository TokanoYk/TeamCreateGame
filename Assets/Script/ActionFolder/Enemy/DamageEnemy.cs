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


	//	----------------------------------------------------
	//	言葉
	//	----------------------------------------------------

	//	各自のゲームオブジェクトを登録する
	public GameObject EnemyHaveWord;

	//	ゲームオブジェクトとboolで判定する用
	public bool 
				miria,
				lady,
				boy,
				poroporo,
				mother,
				mother2,
				arusu,
				shadow,
				woman,
				hot,
				family,
				dear,
				love,
				neck,
				freesia,
				necklace = false;

	//	------------------------------------------------------


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
			//	敵を倒した時にWordに送るアニメーションを判定する
			WordJudment();

			//	Wordの数をカウントする
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

	/// <summary>敵が死んだ時にまわる</summary>
	void Turn()
	{
		rigidbody2D.transform.Rotate(rotateX,rotateY,rotateZ);
	}

	/// <summary>アニメーション再生を判定する</summary>
	void WordJudment()
	{
		//	ID判定して倒された敵が何の文字を持っているのか
		//	文字アニメーションを引き渡すのを変える

		//	【ミリア】の文字を持ったオブジェクトを倒したら
		if(EnemyHaveWord == miria)
		{
			_wordanimation.miriaAnimation = true;
		}

		//	【少女】
		if(EnemyHaveWord == lady)
		{
			_wordanimation.ladyAnimation = true;
		}

		//	【少年】
		if(EnemyHaveWord == boy)
		{
			_wordanimation.boyAnimation = true;
		}

		//	【ぽろぽろ】
		if(EnemyHaveWord == poroporo)
		{
			_wordanimation.poroporoAnimation = true;
		}

		//	【母親】
		if(EnemyHaveWord == mother)
		{
			_wordanimation.motherAnimation = true;
		}

		//	【お母さぁん】
		if(EnemyHaveWord == mother2)
		{
			_wordanimation.mother2Animation = true;
		}

		//	【アルス】
		if(EnemyHaveWord == arusu)
		{
			_wordanimation.arusuAnimation = true;
		}

		//	【草陰】
		if(EnemyHaveWord == shadow)
		{
			_wordanimation.shadowAnimation = true;
		}

		//	【女性】
		if(EnemyHaveWord == woman)
		{
			_wordanimation.womanAnimation = true;
		}

		//	【暖かいもの】
		if(EnemyHaveWord == hot)
		{
			_wordanimation.hotAnimation = true;
		}

		//	【親子】
		if(EnemyHaveWord == family)
		{
			_wordanimation.familyAnimation = true;
		}

		//	【親愛】
		if(EnemyHaveWord == dear)
		{
			_wordanimation.dearAnimation = true;
		}

		//	【愛】
		if(EnemyHaveWord == love)
		{
			_wordanimation.loveAnimation = true;
		}

		//	【首元】
		if(EnemyHaveWord == neck)
		{
			_wordanimation.neckAnimation = true;
		}

		//	【フリージア】
		if(EnemyHaveWord == freesia)
		{
			_wordanimation.freesiaAnimation = true;
		}

		//	【ネックレス】
		if(EnemyHaveWord == necklace)
		{
			_wordanimation.necklaceAnimation = true;
		}

	}
}
