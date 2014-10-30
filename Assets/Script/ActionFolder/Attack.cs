using UnityEngine;
using System.Collections;

//	プレイヤーのアタック関数
public class Attack : MonoBehaviour {

	public GameObject playerAttack;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	/// <summary>攻撃関数</summary>
	public void SetAttack()
	{
		//	Attackの発生
		GameObject instant_object = (GameObject)Instantiate(playerAttack,new Vector2(transform.position.x + 1.5f,transform.position.y + 0.5f),Quaternion.identity);
		//	Attackの消去
		Object.Destroy (instant_object,0.5f);
	}
}
