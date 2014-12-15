using UnityEngine;
using System.Collections;

//	範囲に侵入してジャンプしたら見えない足場を生成する
public class SetScaffolding : MonoBehaviour {

	//	-------------------------------------------
	//	GetComponent用
	//	-------------------------------------------
	private ActionPlayer _player;
	public GameObject PlayerObject;

	//	-------------------------------------------
	//	ゲームオブジェクト登録用
	//	-------------------------------------------
	public GameObject Stages;
	public GameObject Scaffolding;

	public GameObject instant_object;

	//	-------------------------------------------
	//	判定用
	//	-------------------------------------------
	private bool Once = true;


	// Use this for initialization
	void Start () {
		_player = PlayerObject.GetComponent<ActionPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		//	生成ゾーンでジャンプされたら生成する
		if(coll.gameObject.tag == "Player")
		{
			if(_player.jump)
			{
				Set ();
			}
		}
	}

	/// <summary>足場の出現</summary>
	void Set()
	{
		if(Once)
		{
			instant_object = (GameObject)Instantiate(Scaffolding,new Vector2(transform.position.x + 3.2f,transform.position.y + 0.5f),Quaternion.identity);
			Stages = instant_object;
			Stages.transform.parent = transform.parent;
			Once = false;

		}
	}
}
