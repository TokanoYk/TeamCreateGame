using UnityEngine;
using System.Collections;

public class WordAnimation : MonoBehaviour {

	public bool play = false;
	public bool off = true;

	//	-------------------------------------------------------
	//	boolでアニメーションを決める用
	//	-------------------------------------------------------
	public bool miriaAnimation,
	ladyAnimation,
	boyAnimation,
	poroporoAnimation,
	motherAnimation,
	mother2Animation,
	arusuAnimation,
	shadowAnimation,
	womanAnimation,
	hotAnimation,
	familyAnimation,
	dearAnimation,
	loveAnimation,
	neckAnimation,
	freesiaAnimation,
	necklaceAnimation = false;



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
			AnimationProcessing();
			//	【ミリア】
			if(miriaAnimation)
			{
				//	再生するアニメーションを変える
				GetComponent<Animator>().SetBool("Hit",play);
			}
			//	【少女】
			if(ladyAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【少年】
			if(boyAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【ぽろぽろ】
			if(poroporoAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【母親】
			if(motherAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【お母さぁん】
			if(mother2Animation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【アルス】
			if(arusuAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【草陰】
			if(shadowAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【女性】
			if(womanAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【暖かいもの】
			if(hotAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【親子】
			if(familyAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【親愛】
			if(dearAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【愛】
			if(loveAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【首元】
			if(neckAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【フリージア】
			if(freesiaAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

			//	【ネックレス】
			if(necklaceAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
			}

		}
	}


	void AnimationProcessing()
	{
		play = true;
		off = false; 

		Invoke("Reset",0.5f);
	}

	void Reset()
	{
		if(play)
		{
			play = false;
			off = true; 
			//	【ミリア】
			if(miriaAnimation)
			{
				//	終了するアニメーションを変える
				GetComponent<Animator>().SetBool("Hit",play);
				miriaAnimation = false;
			}

			//	【少女】
			if(ladyAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				ladyAnimation = false;
			}
			//	【少年】
			if(boyAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				boyAnimation = false;
			}

			//	【ぽろぽろ】
			if(poroporoAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				poroporoAnimation = false;
			}

			//	【お母さん】
			if(motherAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				motherAnimation = false;
			}

			//	【お母さぁん】
			if(mother2Animation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				mother2Animation = false;
			}
			
			//	【アルス】
			if(arusuAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				arusuAnimation = false;
			}

			//	【草陰】
			if(shadowAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				shadowAnimation = false;
			}
			
			//	【女性】
			if(womanAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				womanAnimation = false;
			}

			//	【暖かいもの】
			if(hotAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				hotAnimation = false;
			}

			//	【親子】
			if(familyAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				familyAnimation = false;
			}

			//	【親愛】
			if(dearAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				dearAnimation = false;
			}

			//	【愛】
			if(loveAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				loveAnimation = false;
			}

			//	【首元】
			if(neckAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				neckAnimation = false;
			}

			//	【フリージア】
			if(freesiaAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				freesiaAnimation = false;
			}

			//	【ネックレス】
			if(necklaceAnimation)
			{
				GetComponent<Animator>().SetBool("Hit",play);
				necklaceAnimation = false;
			}

		}
	}
}
