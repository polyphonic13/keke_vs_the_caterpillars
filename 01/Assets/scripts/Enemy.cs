using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int life = 5;
	
	bool attackProximity = false;
	
	public void Init() {
		this.gameObject.tag = "enemy";
	}

	public void LifeCheck() {
		if(life <= 0) {
			Debug.Log("killing: " + this.gameObject.name);
			Destroy(this.gameObject);
		}
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
