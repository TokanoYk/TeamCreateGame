﻿using UnityEngine;
using System.Collections;

//	Boss画面に入ったら出られないように壁を作る
public class BossBattleStart : MonoBehaviour {

	public GameObject Stages;
	public GameObject Wall,Wall2;

	private bool Once = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		//	生成ゾーンでジャンプされたら生成する
		if(coll.gameObject.tag == "Player")
		{
			CreateWall();
		}
	}

	void CreateWall()
	{
		if(Once)
		{
			Stages = (GameObject)Instantiate(Wall,new Vector2(transform.position.x - 4.3f, transform.position.y + 3),Quaternion.identity);
			Stages = (GameObject)Instantiate(Wall2,new Vector2(transform.position.x + 13f, transform.position.y + 3),Quaternion.identity);
			Stages.transform.parent = transform.parent; 
			Once = false;
		}
	}
}