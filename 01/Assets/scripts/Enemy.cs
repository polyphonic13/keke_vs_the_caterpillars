using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int life = 5;
	
	float attackProximity = 5f;
	bool isInAttackProximity = false;
	
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
		return GameObject.Find("keke").transform.position;	
	}
	
	public bool ProximityCheck() {
		var playerPos = FindPlayer();
		var thisPos = this.transform.position;
		var distanceFromPlayer = Vector3.Distance(playerPos, thisPos);
		if(distanceFromPlayer < attackProximity) {
			isInAttackProximity = true;
		} else {
			isInAttackProximity = false;
		}
		// Debug.Log("Enement/ProximityCheck, thisPos = " + thisPos + ", playerPos = " + playerPos + ", distanceFromPlayer = " + distanceFromPlayer + ", isInAttackProximity = " + isInAttackProximity);
		return isInAttackProximity;
	}
	
	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
