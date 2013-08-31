using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	public bool collected = false;
	public AnimationClip defaultAnimation;
	public AnimationClip cockedAnimation;
	public AnimationClip fireAnimation;
	
	Animation _animation;
	bool _hasAnimations = false;
	bool _canFire = false;
	// Use this for initialization
	void Awake () {
		_animation = GetComponent<Animation>();
		if(!defaultAnimation) {
			_animation = null;
		}
		if(!cockedAnimation) {
			_animation = null;
		}
		if(!fireAnimation) {
			_animation = null;
		}
		if(_animation) {
			_hasAnimations = true;
		}
		Debug.Log("Slingshot/Awake, _hasAnimations = " + _hasAnimations + ", _animation = " + _animation + ", _animation[cocked] = " + cockedAnimation.name);
		_animation.Play(defaultAnimation.name);
	}
	
	// Update is called once per frame
	void Update () {
		if(collected && _hasAnimations) {
			if(Input.GetKey(KeyCode.F)) {
				Debug.Log("Slingshot play cocked, cocked = " + cockedAnimation.name + ", _animation = " + _animation);
				_animation.Play(cockedAnimation.name);
				_canFire = true;
			}
			if(Input.GetKey(KeyCode.G)) {
				if(_canFire) {
					Debug.Log("Slingshot play fire");
					_animation.Play(fireAnimation.name);
					_canFire = false;
				}
			}
		}
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
