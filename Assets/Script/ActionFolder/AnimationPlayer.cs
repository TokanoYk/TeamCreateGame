using UnityEngine;
using System.Collections;

public class AnimationPlayer : MonoBehaviour {

	//接地判定する対象のLayer
	public LayerMask groundLayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DrawAnimation ();
	}

	void DrawAnimation()
	{
		//接地しているかどうかを判定する
		//自分の基点の少し上と少し下の2点を渡して、その間にColliderがあればtrueが返る
		bool ground = Physics2D.Linecast(
				transform.position - transform.up * 0.5f,
				transform.position + transform.up * 0.1f,
				groundLayer
				);
		//Debug.Log("Ground ->" + ground);

		//Animatorコンポーネントの「Grounded」プロパティに取得した接地状態を渡す
		GetComponent<Animator>().SetBool("Ground",ground);

	}
}
