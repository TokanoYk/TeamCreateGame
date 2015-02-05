using UnityEngine;
using System.Collections;

public class PlaySE : MonoBehaviour {

	//	取得
	public GameObject textObject;
	private textManager _text;

	bool doorOne = false;
	bool dashOne = false;

	public AudioClip door;
	public AudioClip dash;

	// Use this for initialization
	void Start ()
	{
		_text = textObject.GetComponent<textManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		PlaingSE ();
	}

	void PlaingSE()
	{
		if(_text.se == "door")
		{
			if(!doorOne)
			{
				doorOne = true;
				audio.PlayOneShot(door);
			}
		}

		if(_text.se == "dash")
		{
			if(!dashOne)
			{
				dashOne = true;
				audio.PlayOneShot(dash);
			}
		}

		//	応急処置
		if(_text.se == "se")
		{
			doorOne = false;
			dashOne = false;
		}

	}

}
