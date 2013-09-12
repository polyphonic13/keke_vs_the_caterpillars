using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int life = 5;
	
	bool attackProximity = false;
	
	private float moveSpeed = 0;
	
	public void Init() {
		this.gameObject.tag = "enemy";
	}

	public bool LifeCheck() {
		if(life <= 0) {
			Debug.Log("killing: " + this.gameObject.name);
			Destroy(this.gameObject);
			return false;
		} else {
			return true;
		}
	}
	
	public Vector3 FindPlayer() {
		var player = GameObject.Find("keke");
		var playerPos = player.transform.position;
		Debug.Log("Enemy/FindPlayer, playerPos = " + playerPos);
		return playerPos;	
	}
	
	public bool ProximityCheck() {
		return attackProximity;
	}
	
	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
		LifeCheck();
	}
}
