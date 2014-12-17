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
				GetComponent<Animator>().SetBool("MiriaWord",play);
			}
			//	【少女】
			if(ladyAnimation)
			{
				GetComponent<Animator>().SetBool("LadyWord",play);
			}

			//	【少年】
			if(boyAnimation)
			{
				GetComponent<Animator>().SetBool("BoyWord",play);
			}

			//	【ぽろぽろ】
			if(poroporoAnimation)
			{
				GetComponent<Animator>().SetBool("PoroporoWord",play);
			}

			//	【母親】
			if(motherAnimation)
			{
				GetComponent<Animator>().SetBool("MotherWord",play);
			}

			//	【お母さぁん】
			if(mother2Animation)
			{
				GetComponent<Animator>().SetBool("Mother2Word",play);
			}

			//	【アルス】
			if(arusuAnimation)
			{
				GetComponent<Animator>().SetBool("ArusuWord",play);
			}

			//	【草陰】
			if(shadowAnimation)
			{
				GetComponent<Animator>().SetBool("ShadowWord",play);
			}

			//	【女性】
			if(womanAnimation)
			{
				GetComponent<Animator>().SetBool("WomanWord",play);
			}

			//	【暖かいもの】
			if(hotAnimation)
			{
				GetComponent<Animator>().SetBool("HotWord",play);
			}

			//	【親子】
			if(familyAnimation)
			{
				GetComponent<Animator>().SetBool("FamilyWord",play);
			}

			//	【親愛】
			if(dearAnimation)
			{
				GetComponent<Animator>().SetBool("DearWord",play);
			}

			//	【愛】
			if(loveAnimation)
			{
				GetComponent<Animator>().SetBool("LoveWord",play);
			}

			//	【首元】
			if(neckAnimation)
			{
				GetComponent<Animator>().SetBool("NeckWord",play);
			}

			//	【フリージア】
			if(freesiaAnimation)
			{
				GetComponent<Animator>().SetBool("FreesiaWord",play);
			}

			//	【ネックレス】
			if(necklaceAnimation)
			{
				GetComponent<Animator>().SetBool("NeclaceWord",play);
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
				GetComponent<Animator>().SetBool("MiriaWord",play);
				miriaAnimation = false;
			}

			//	【少女】
			if(ladyAnimation)
			{
				GetComponent<Animator>().SetBool("LadyWord",play);
				ladyAnimation = false;
			}
			//	【少年】
			if(boyAnimation)
			{
				GetComponent<Animator>().SetBool("BoyWord",play);
				boyAnimation = false;
			}

			//	【ぽろぽろ】
			if(poroporoAnimation)
			{
				GetComponent<Animator>().SetBool("PoroporoWord",play);
				poroporoAnimation = false;
			}

			//	【お母さん】
			if(motherAnimation)
			{
				GetComponent<Animator>().SetBool("MotherWord",play);
				motherAnimation = false;
			}

			//	【お母さぁん】
			if(mother2Animation)
			{
				GetComponent<Animator>().SetBool("Mother2Word",play);
				mother2Animation = false;
			}
			
			//	【アルス】
			if(arusuAnimation)
			{
				GetComponent<Animator>().SetBool("ArusuWord",play);
				arusuAnimation = false;
			}

			//	【草陰】
			if(shadowAnimation)
			{
				GetComponent<Animator>().SetBool("ShadowWord",play);
				shadowAnimation = false;
			}
			
			//	【女性】
			if(womanAnimation)
			{
				GetComponent<Animator>().SetBool("WomanWord",play);
				womanAnimation = false;
			}

			//	【暖かいもの】
			if(hotAnimation)
			{
				GetComponent<Animator>().SetBool("HotWord",play);
				hotAnimation = false;
			}

			//	【親子】
			if(familyAnimation)
			{
				GetComponent<Animator>().SetBool("FamilyWord",play);
				familyAnimation = false;
			}

			//	【親愛】
			if(dearAnimation)
			{
				GetComponent<Animator>().SetBool("DearWord",play);
				dearAnimation = false;
			}

			//	【愛】
			if(loveAnimation)
			{
				GetComponent<Animator>().SetBool("LoveWord",play);
				loveAnimation = false;
			}

			//	【首元】
			if(neckAnimation)
			{
				GetComponent<Animator>().SetBool("NeckWord",play);
				neckAnimation = false;
			}

			//	【フリージア】
			if(freesiaAnimation)
			{
				GetComponent<Animator>().SetBool("FreesiaWord",play);
				freesiaAnimation = false;
			}

			//	【ネックレス】
			if(necklaceAnimation)
			{
				GetComponent<Animator>().SetBool("NeclaceWord",play);
				necklaceAnimation = false;
			}

		}
	}
}
