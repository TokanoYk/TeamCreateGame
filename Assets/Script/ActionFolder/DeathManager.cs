using UnityEngine;
using System.Collections;

//	死んだら呼ばれる
public class DeathManager : MonoBehaviour {

	//public bool test = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	/// <summary>ウォームが死んだら呼ばれる</summary>
	public void DeathWorm()
	{
		//	オブジェクトを消す
		Destroy (gameObject);
	}


}
