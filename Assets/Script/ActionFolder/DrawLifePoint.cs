using UnityEngine;
using System.Collections;

public class DrawLifePoint : MonoBehaviour {

	private ActionPlayer _player;
	public GameObject PlayerObject;

	// Use this for initialization
	void Start () {
		_player = PlayerObject.GetComponent<ActionPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		DrawHp ();
	}

	void DrawHp()
	{
		guiText.text = "<Color=black>読者数　" + _player.LifePoint.ToString() + "人</Color>";

	}
}
