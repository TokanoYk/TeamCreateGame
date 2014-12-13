using UnityEngine;
using System.Collections;

//	プレイヤーのアタック関数
public class Attack : MonoBehaviour {

	public GameObject playerAttack;

	public GameObject PlayerObject;


	/// <summary>攻撃関数</summary>
	public void SetAttack()
	{
		//PlayerObject = (GameObject)Instantiate(playerAttack,new Vector2(transform.position.x + 1.5f,transform.position.y + 0.5f),Quaternion.identity);


		//	Attackの発生
		GameObject instant_object = (GameObject)Instantiate(playerAttack,new Vector2(transform.position.x + 1.5f,transform.position.y + 0.5f),Quaternion.identity);
		PlayerObject = instant_object;
		PlayerObject.transform.parent = transform.parent; 
		//	Attackの消去
		Object.Destroy (instant_object,0.5f);
	}
}
