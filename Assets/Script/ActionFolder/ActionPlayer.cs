using UnityEngine;
using System.Collections;

//	強制横スクロールアクションステージのスクリプト
public class ActionPlayer : MonoBehaviour {

	//	-------------------------------------------
	//	GetComponent用
	//	-------------------------------------------
	public GameObject AttackObject;
	private Attack _attack; 

	private StageMove _stageMove;
	public GameObject StageObject;

	//	点滅処理のレンダー
	private SpriteRenderer _renderer;

	//	-------------------------------------------
	//	判定用
	//	-------------------------------------------
	//	ジャンプ中ならtrue
	public bool jump = false;
	private bool damageFlag = false;
	
	//	アニメーションのフラグ
	private bool animationAttack = false;
	private bool animationJumpAttack = false;

	private bool OnScaffolding = false;

	//	-------------------------------------------
	//	ステータス
	//	-------------------------------------------
	[SerializeField]
	//	ジャンプする力
	private float force = 2.1f;
	//	足場に乗っていた場合のジャンプ力
	private float onScaffoldingForse = 2.5f;
	//	プレイヤーの体力
	public int LifePoint = 10;
	//	攻撃力
	public int attackPower = 1;

	//	プレイヤーの移動スピード(開発用)
	private float moveSpeed = 10.0f;
	

	// Use this for initialization
	void Start () {
		_attack = AttackObject.GetComponent<Attack> ();
		_stageMove = StageObject.GetComponent<StageMove>(); 
		_renderer = gameObject.GetComponent<SpriteRenderer> ();

		//	ステージが始まったら全回復
		LifePoint = 10;
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

		//	スクロールが止まったら動けるように鳴る
		if(_stageMove.StageStop)
		{
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
		}

		//	↑キーでジャンプ
		if(!jump && Input.GetKey(KeyCode.UpArrow))
		{
			Jump();
		}

		//	攻撃
		if(Input.GetKeyDown(KeyCode.Space))
		{
			_attack.SetAttack();
			animationAttack = true;

			Invoke("BoolReset",0.5f);
			GetComponent<Animator>().SetBool("Attack",animationAttack);

			if(jump)
			{
				animationJumpAttack = true;
				Invoke("BoolReset",0.5f);
				GetComponent<Animator>().SetBool("JumpAttack",animationJumpAttack);
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

		//	足場に乗っていた場合ジャンプ力の値を増やす
		if(OnScaffolding /*&& !jump*/)
		{
			rigidbody2D.AddForce (transform.up * onScaffoldingForse, ForceMode2D.Impulse);
		}
		/*
		if(!jump)
		{
			OnScaffolding = false;
		}*/
	}

	//	ぶつかっていたら
	void OnTriggerStay2D(Collider2D coll)
	{
		//	床と足場に衝突したらfalseに戻す
		if(coll.gameObject.tag == "Floor" || coll.gameObject.tag == "Scaffolding")
		{
			jump = false;
			//	足場に乗っているとジャンプ力を変える
			if(coll.gameObject.tag == "Scaffolding")
			{
				OnScaffolding = true;
			}
		}

		//	足場から降りた用の判定
		if(coll.gameObject.tag == "Floor")
		{
			OnScaffolding = false;
		}
		
		//	デスゾーンに落ちたら死亡
		if(coll.gameObject.tag == "DeathZone")
		{
			Death();
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//	BoxCollでダメージ判定を取る


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
		LifePoint -= 1;

		// コルーチン開始
		StartCoroutine("WaitForIt");
		//	体力がなくなったらdeadをtrueにする
		if(LifePoint <= 0)
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
		//	再読み込み
		Application.LoadLevel(Application.loadedLevel);
	}



	void OnGUI()
	{
		//	プレイヤーの体力（読者数）を左上に表示
		//GUI.Label (new Rect (0, 0, 10, 10));
	}
}
