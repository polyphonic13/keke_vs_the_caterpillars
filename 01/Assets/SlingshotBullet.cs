using UnityEngine;
using System.Collections;

public class SlingshotBullet : MonoBehaviour {
	
	public float speed = 20f;
	public int life = 3;
	
	public float GetSpeed() {
		return speed;
	}

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(life);
		KillSelf();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision target) {
		Debug.Log("Bullet/OnCollisionEnter, tag = " + target.transform.tag);
		if(target.transform.tag == "enemy") {
			Debug.Log("Bullet hit an enemy");
			//KillSelf();
			// Destroy(target.gameObject);
			target.gameObject.GetComponent<Enemy>().life--;
		}
	}
	
	void KillSelf() {
		Debug.Log("SlingshotBullet/KillSelf");
		Destroy(gameObject);	
	}
}
