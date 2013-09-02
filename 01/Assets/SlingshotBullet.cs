using UnityEngine;
using System.Collections;

public class SlingshotBullet : MonoBehaviour {
	
	public float speed = 20f;
	public float life = 10f;
	
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
	
	void KillSelf() {
		Debug.Log("SlingshotBullet/KillSelf");
		Destroy(gameObject);	
	}
}
