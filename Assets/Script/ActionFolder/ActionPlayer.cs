using UnityEngine;
using System.Collections;

//	強制横スクロールアクションステージのスクリプト
public class ActionPlayer : MonoBehaviour {

	//	-------------------------------------------
	//	GetComponent用
	//	-------------------------------------------
	public GameObject AttackObject;
	private Attack _attack; 
	//	点滅処理のレンダー
	private SpriteRenderer _renderer;

	//	-------------------------------------------
	//	判定用
	//	-------------------------------------------
	//	ジャンプ中ならtrue
	private bool jump = false;
	private bool damageFlag = false;

	//	アニメーションのフラグ
	private bool animationAttack = false;
	private bool animationJumpAttack = false;

	//	プレイヤーが死んだら
	//public bool dead = false;

	//	-------------------------------------------
	//	ステータス
	//	-------------------------------------------
	//	ジャンプする力
	public float force = 2.1f;
	//	プレイヤーの体力
	public int playerLife = 10;
	//	攻撃力
	public int attackPower = 1;

	//	プレイヤーの移動スピード(開発用)
	private float moveSpeed = 10.0f;
	

	// Use this for initialization
	void Start () {
		_attack = AttackObject.GetComponent<Attack> ();
		_renderer = gameObject.GetComponent<SpriteRenderer> ();

		//	ステージが始まったら全回復
		playerLife = 10;

	}
	
	// Update is called once per frame
	void Update ()
	{
		PlayerMove ();
		Flashing ();
	}
	
	/// <summary>プレイヤーの移動関数</summary>
	void PlayerMove()
	{
		//	プレイヤーの位置を保存する
		Vector2 NewPosition = transform.position;
		
		//	右に移動する
		if (Input.GetKey (KeyCode.RightArrow))
		{
			NewPosition.x += moveSpeed * Time.deltaTime;
		}
		
		//	左に移動する
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			NewPosition.x -= moveSpeed * Time.deltaTime;
		}

		//	ジャンプ
		if(!jump && Input.GetKey(KeyCode.Space) || !jump && Input.GetKey(KeyCode.X))
		{
			Jump();
		}

		//	攻撃
		if(Input.GetKeyDown(KeyCode.Return)||Input.GetKeyDown(KeyCode.Z))
		{
			_attack.SetAttack();
			animationAttack = true;

			Invoke("BoolReset",0.5f);
			GetComponent<Animator>().SetBool("Attack",animationAttack);

			if(jump)
			{
				//if(Input.GetKeyDown(KeyCode.Return))
				//{
					animationJumpAttack = true;
					Invoke("BoolReset",0.5f);
					GetComponent<Animator>().SetBool("JumpAttack",animationJumpAttack);
				//}
			}
		}
		transform.position = NewPosition;
	}

	/// <summary>攻撃モーションの判定用</summary>
	void BoolReset()
	{
		if(animationAttack)
		{
			animationAttack = false;
			GetComponent<Animator>().SetBool("Attack",animationAttack);
		}

		if(animationJumpAttack)
		{
			animationJumpAttack = false;
			GetComponent<Animator>().SetBool("JumpAttack",animationJumpAttack);
		}
	}

	/// <summary>プレイヤーのジャンプ関数</summary>
	void Jump()
	{
		jump = true;

		//	オブジェクトの上方向に瞬間的にジャンプする
		rigidbody2D.AddForce (transform.up * force, ForceMode2D.Impulse);
	}

	//	ぶつかっていたら
	void OnTriggerStay2D(Collider2D coll)
	{
		//	床と衝突したらfalseに戻す
		if(coll.gameObject.tag == "Floor")
		{
			jump = false;
		}

		//	デスゾーンに落ちたら死亡
		if(coll.gameObject.tag == "DeathZone")
		{
			Death();
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{

		//	敵やボス,攻撃,障害物にぶつかったら攻撃を食らう
		if(coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Boss" ||
		   coll.gameObject.tag == "BossAttack" || coll.gameObject.tag == "Obstacle")
		{
			//	ダメージフラグをtrueにする
			damageFlag = true;
			if(damageFlag)
			{
				Damage();
			}
		}
	}

	/// <summary>敵に攻撃された時に呼ぶ関数</summary>
	void Damage () 
	{
		Debug.Log("Damage!");
		playerLife -= 1;

		// コルーチン開始
		StartCoroutine("WaitForIt");
		//	体力がなくなったらdeadをtrueにする
		if(playerLife <= 0)
		{
			Death();
		}
	}

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
		yield return new WaitForSeconds (1);


		//	１秒間無敵になってる？
		//	１秒後ダメージフラグをfalseにして点滅を戻す
		damageFlag = false;
		_renderer.color = new Color (1f, 1f, 1f, 1f);
	}

	/// <summary>プレイヤーが死んだ時の関数</summary>
	void Death()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	void OnGUI()
	{
		//	プレイヤーの体力（読者数）を左上に表示
		//GUI.Label (new Rect (0, 0, 10, 10));
	}
}
