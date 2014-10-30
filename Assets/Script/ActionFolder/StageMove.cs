using UnityEngine;
using System.Collections;

//	ステージをスクロールさせると見せかけて動かすスクリプト
public class StageMove : MonoBehaviour {

	//	ステージのスクロール速度
	private float moveSpeed = 2.3f;

	public bool StageStop = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!StageStop)
		{
			Scroll ();
		}
	}

	void Scroll()
	{
		//	場所を格納
		Vector2 NewPosition = transform.position ;
		//	ステージの移動
		NewPosition.x -= moveSpeed * Time.deltaTime;
		//	場所の上書き
		transform.position = NewPosition;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "StopZone")
		{
			StageStop = true;
		}
	}
}
