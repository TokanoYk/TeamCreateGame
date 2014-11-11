using UnityEngine;
using System.Collections;

//	ステージをスクロールさせると見せかけて動かすスクリプト
public class StageMove : MonoBehaviour {

	//	-------------------------------------------
	//	ステータス
	//	-------------------------------------------
	//	ステージのスクロール速度
	private float moveSpeed = 2.3f;

	//	-------------------------------------------
	//	判定用
	//	-------------------------------------------
	public bool StageStop = false;

	//	-------------------------------------------
	//	GetComponent用
	//	-------------------------------------------
	private ActionPlayer _player;
	public GameObject PlayerObject;


	// Use this for initialization
	void Start () {
		_player = PlayerObject.GetComponent<ActionPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!StageStop)
		{
			Scroll ();
		}
	}

	public void Scroll()
	{
		if(_player.stageStart)
		{
			//	場所を格納
			Vector2 NewPosition = transform.position ;
			//	ステージの移動
			NewPosition.x -= moveSpeed * Time.deltaTime;
			//	場所の上書き
			transform.position = NewPosition;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "StopZone")
		{
			StageStop = true;
		}
	}
}
