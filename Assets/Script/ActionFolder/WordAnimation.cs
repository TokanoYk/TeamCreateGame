using UnityEngine;
using System.Collections;

public class WordAnimation : MonoBehaviour {

	public bool play = false;
	public bool off = true;

	// Use this for 
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		DrawWordAnimation();
	}

	void DrawWordAnimation()
	{
			if(!off)
			{
				play = true;
				off = false; 
				GetComponent<Animator>().SetBool("Hit",play);
				Invoke("BoolReset",0.5f);
			}
	}

	void BoolReset()
	{
		if(play)
		{
			play = false;
			off = true; 

			GetComponent<Animator>().SetBool("Hit",play);
		}
	}
}
