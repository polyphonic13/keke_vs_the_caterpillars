using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	public bool collected = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider target) {
		if(!collected) {
			if(target.gameObject.tag == "Player") {
				collected = true;
				Debug.Log("Player hit slingshot");
			}
		}
	}
}
