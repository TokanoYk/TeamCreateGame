using UnityEngine;
using System.Collections;

public class BossAttack : MonoBehaviour {

	//	-------------------------------------------
	//	ゲームオブジェクトの登録
	//	-------------------------------------------
	[SerializeField]
	public GameObject BossBulletObject1,BossBulletObject2,BossBulletObject3;

	//	出現時間
	private float waitingTime = 2.5f;

	void Awake(){
			InvokeRepeating("SetBossAttack", waitingTime, waitingTime);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetBossAttack()
	{
		//	Attackの発生
		GameObject instant_object = (GameObject)Instantiate(BossBulletObject1,new Vector3(transform.position.x - 1,transform.position.y,transform.position.z),Quaternion.identity);
		GameObject instant_object1 = (GameObject)Instantiate(BossBulletObject2,new Vector3(transform.position.x - 1,transform.position.y,transform.position.z),Quaternion.identity);
		GameObject instant_object2 = (GameObject)Instantiate(BossBulletObject3,new Vector3(transform.position.x - 1,transform.position.y,transform.position.z),Quaternion.identity);
		//	Attackの消去
		Object.Destroy (instant_object,5.0f);
		Object.Destroy (instant_object1,5.0f);
		Object.Destroy (instant_object2,5.0f);
	}
}
