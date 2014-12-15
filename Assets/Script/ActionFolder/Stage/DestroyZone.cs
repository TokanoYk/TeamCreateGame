using UnityEngine;
using System.Collections;

//	足場に乗っていない場合でなおかつ足場が出現していて引っかかるのを防止する
public class DestroyZone : MonoBehaviour {

	private SetScaffolding _scaffold;
	public GameObject ScaffoldObject;

	// Use this for initialization
	void Start () {
		_scaffold = ScaffoldObject.GetComponent<SetScaffolding> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//	プレイヤーとぶつかったら
		if(coll.gameObject.tag == "Player")
		{
			DeleteScaffolding();
		}
	}

	//	足場を消す
	void DeleteScaffolding()
	{
		//	消す(ステージが消えてる)
		//	ステージの子のScaffoldingを消す
		Destroy (_scaffold.instant_object);
	}
}
