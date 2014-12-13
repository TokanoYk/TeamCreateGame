using UnityEngine;
using System.Collections;

//	強制横スクロールアクションステージのスクリプト.
public class ActionPlayer : MonoBehaviour {

	//	-------------------------------------------
	//	GetComponent用.
	//	-------------------------------------------
	public GameObject AttackObject;
	private Attack _attack; 

	private StageMove _stageMove;
	public GameObject StageObject;

	//	点滅処理のレンダー.
	private SpriteRenderer _renderer;

	//	-------------------------------------------
	//	判定用.
	//	-------------------------------------------
	//	ジャンプ中ならtrue.
	public bool jump = false;
	private bool damageFlag = false;

	public bool stageStart = false;
	private bool Once = true;

	//	アニメーションのフラグ.
	private bool animationAttack = false;
	private bool animationJumpAttack = false;
//	private bool animationDash = true;
	private bool animationStop = false;

	private bool OnScaffolding = false;

	//	-------------------------------------------
	//	オーディオ関連
	//	-------------------------------------------
	//public AudioClip slash;

	//	-------------------------------------------
	//	ステータス.
	//	-------------------------------------------
	[SerializeField]
	//	ジャンプする力.
	private float force = 2.1f;
	//	足場に乗っていた場合のジャンプ力.
	private float onScaffoldingForse = 2.5f;
	//	プレイヤーの体力.
	public int LifePoint = 300;
	//	【言葉】のカウント.
	public int words = 0;

	//	攻撃力.
	public int attackPower = 1;

	//	プレイヤーの移動スピード(開発用).
	private float moveSpeed = 10.0f;
	

	// Use this for initialization
	void Start () {
		_attack = AttackObject.GetComponent<Attack> ();
		_stageMove = StageObject.GetComponent<StageMove>(); 
		_renderer = gameObject.GetComponent<SpriteRenderer> ();

		//	ステージが始まったら全回復.
		LifePoint = 300;
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
		//	プレイヤーの位置を保存する.
		Vector2 NewPosition = transform.position;

		//	スクロールが止まったら動けるようになる.
		if(_stageMove.StageStop)
		{
			//animationDash = false;
			//animationStop = true;

			//GetComponent<Animator>().SetBool("Dash",animationDash);
			//GetComponent<Animator>().SetBool("Stop",animationStop);

			//	右に移動する.
			if (Input.GetKey (KeyCode.RightArrow))
			{
				NewPosition.x += moveSpeed * Time.deltaTime;
				//animationDash = true;
				//GetComponent<Animator>().SetBool("Dash",animationDash);
			}
			
			//	左に移動する.
			if (Input.GetKey (KeyCode.LeftArrow))
			{
				NewPosition.x -= moveSpeed * Time.deltaTime;
				//animationDash = true;
				//GetComponent<Animator>().SetBool("Dash",animationDash);
			}
		}

		//	CでClear
		if(Input.GetKeyDown(KeyCode.C))
		{
			FadeManager.Instance.LoadLevel("ClearNovelPart",1.0f);
		}

		//	Enterでステージが動く.
		if(Input.GetKeyDown(KeyCode.Return))
		{
			if(Once)
			{
				stageStart = true;
				GetComponent<Animator>().SetBool("Dash",stageStart);
				Once = false;
			}
		}

		//	↑キーでジャンプ.
		if(!jump && Input.GetKey(KeyCode.UpArrow))
		{
			Jump();
		}

		//	攻撃.
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//	slashはslashだけの音スクリプト作ってアニメーションでPlayする

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

		if(animationStop)
		{
			animationStop = true;
			GetComponent<Animator>().SetBool("Stop",animationStop);
		}

	}

	/// <summary>プレイヤーのジャンプ関数.</summary>
	void Jump()
	{
		jump = true;

		GetComponent<Animator>().SetBool("Ground",jump);

		//	オブジェクトの上方向に瞬間的にジャンプする.
		rigidbody2D.AddForce (transform.up * force, ForceMode2D.Impulse);

		//	足場に乗っていた場合ジャンプ力の値を増やす.
		if(OnScaffolding)
		{
			rigidbody2D.AddForce (transform.up * onScaffoldingForse, ForceMode2D.Impulse);
		}
	}

	//	ぶつかっていたら.
	void OnTriggerStay2D(Collider2D coll)
	{
		//	床と足場に衝突したらfalseに戻す.
		if(coll.gameObject.tag == "Floor" || coll.gameObject.tag == "Scaffolding")
		{
			jump = false;
			GetComponent<Animator>().SetBool("Ground",jump);
			//	足場に乗っているとジャンプ力を変える.
			if(coll.gameObject.tag == "Scaffolding")
			{
				OnScaffolding = true;
			}
		}

		//	足場から降りた用の判定.
		if(coll.gameObject.tag == "Floor")
		{
			OnScaffolding = false;
		}
		
		//	デスゾーンに落ちたら死亡.
		if(coll.gameObject.tag == "DeathZone")
		{
			Death();
		}
	}

	public void RedirectedOnTriggerEnter2D (Collider2D coll)
	{
		//処理を記述
		//	敵やボス,攻撃,障害物にぶつかったら攻撃を食らう.
		if(coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Boss" ||
		   coll.gameObject.tag == "BossAttack" || coll.gameObject.tag == "Obstacle")
		{
			//	ダメージフラグをtrueにする.
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
		LifePoint -= 30;

		// コルーチン開始.
		StartCoroutine("WaitForIt");
		//	体力がなくなったらdeadをtrueにする.
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
		//	１秒間処理を止める.
		yield return new WaitForSeconds (1);


		//	１秒間無敵になってる？.
		//	１秒後ダメージフラグをfalseにして点滅を戻す.
		damageFlag = false;
		_renderer.color = new Color (1f, 1f, 1f, 1f);
	}

	/// <summary>プレイヤーが死んだ時の関数</summary>
	void Death()
	{
		//	再読み込み.
		Application.LoadLevel(Application.loadedLevel);
	}
	
	void OnGUI()
	{
		//	プレイヤーの体力（読者数）を左上に表示.
		//GUI.Label (new Rect (0, 0, 10, 10));
	}
}
