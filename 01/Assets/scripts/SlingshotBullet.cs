﻿using UnityEngine;
using System.Collections;

public class SlingshotBullet : MonoBehaviour {
	
	public float speed = 20f;
	public int lifeTime = 3;
	
	public float GetSpeed() {
		return speed;
	}

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(lifeTime);
		KillSelf();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision target) {
		//Debug.Log("Bullet/OnCollisionEnter, tag = " + target.transform.tag + ", name = " + target.gameObject.name);
		if(target.transform.tag == "enemy") {
			//KillSelf();
			// Destroy(target.gameObject);
			Enemy e = target.gameObject.GetComponent<Enemy>();
			if(e != null) {
				Debug.Log("Bullet hit an enemy: " + e + ", life = " + e.life);
				if(e.life > 0) {
					e.life--;
				}
			}
//			target.gameObject.GetComponent<Enemy>().life--;
		}
	}
	
	void KillSelf() {
		//Debug.Log("SlingshotBullet/KillSelf");
		Destroy(gameObject);	
	}
}
