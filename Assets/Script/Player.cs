using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//	移動スピード
	float moveSpeed = 10.0f;


	//public float time = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		PlayerMove ();
	}

	void PlayerMove()
	{

		//	プレイヤーの位置を保存する
		//Vector3 NewPosition = transform.position;

		//Time.deltaTime;
		
		Vector3 NewPosition = transform.position;

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


		//	上に移動する
		if (Input.GetKey (KeyCode.UpArrow))
		{
			NewPosition.y += moveSpeed * Time.deltaTime;
		}


		//	下に移動する
		if (Input.GetKey (KeyCode.DownArrow))
		{
			NewPosition.y -= moveSpeed * Time.deltaTime;
		}

		transform.position = NewPosition;
	}


}
