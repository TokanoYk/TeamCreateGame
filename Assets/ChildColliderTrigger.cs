using UnityEngine;
using System.Collections;

public class ChildColliderTrigger : MonoBehaviour {

	private ActionPlayer _player;
	public GameObject ParentObject;
	
	// Use this for initialization
	void Start () {
		_player = ParentObject.GetComponent<ActionPlayer> ();
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		_player.RedirectedOnTriggerEnter2D (coll);
	}
}
