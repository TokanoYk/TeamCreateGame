using UnityEngine;
using System.Collections;

public class ActionSE : MonoBehaviour {

	public AudioClip slash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SoundPlay()
	{
		audio.PlayOneShot (slash);
	}
}
