using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	public Rigidbody bullet;

	public bool collected = false;
	public AnimationClip defaultAnimation;
	public AnimationClip cockedAnimation;
	public AnimationClip fireAnimation;
	
	public float cockedAnimationSpeed = 1;
	public float fireAnimationSpeed = 1;
	
	Animation _animation;
	bool _hasAnimations = false;
	bool _canFire = false;
	float _lastFireTime = -1;
	float _fireRepeatTime = 0.75f; // make sure that the slingshot doesn't fire too rapidly
	
	float _bulletSpeed = 10f;
	// Bullet _bullet;
	
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
			Debug.Log("Slingshot/Awake, _hasAnimations = " + _hasAnimations + ", _animation = " + _animation + ", _animation[cocked] = " + cockedAnimation.name);
			//_animation.Play(defaultAnimation.name); 
			_animation.Play("ss_default");
			_animation[cockedAnimation.name].speed = cockedAnimationSpeed;
			_animation[fireAnimation.name].speed = fireAnimationSpeed;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
//		if(collected && _hasAnimations) {
			if(Input.GetKey(KeyCode.F)) {
				if(Time.time - _lastFireTime > _fireRepeatTime) {
					_lastFireTime = Time.time;
					/*
					Debug.Log("Slingshot play cocked, _canFire = " + _canFire);
					if(!_canFire) {
						StartCoroutine(Cock());
					} else {
	*/					StartCoroutine(Fire());
						//_animation.Play(cockedAnimation.name);
					// }
				}
			}
//		}
	}
	
	void OnTriggerEnter(Collider target) {
		if(!collected) {
			if(target.gameObject.tag == "Player") {
				collected = true;
				Debug.Log("Player hit slingshot");
			}
		}
	}

	IEnumerator Cock() {
		_animation.Play(cockedAnimation.name);
		_canFire = true;
		yield return true;
	}
	
	IEnumerator Fire() {
		_animation.Play(fireAnimation.name);
		
		float forward = this.transform.position.z;
		float up = this.transform.position.y + 1f;
		float right = this.transform.position.x;
//		Vector3 pos = Vector3(forward, up, right);
		Rigidbody bulletClone = (Rigidbody) Instantiate(bullet, new Vector3(right, up, forward), transform.rotation);
//		Rigidbody bulletClone = (Rigidbody) Instantiate(bullet, transform.position, transform.rotation);

//		bulletClone.velocity = this.transform.TransformDirection (Vector3.forward * _bulletSpeed);
		float speed = bulletClone.GetComponent<SlingshotBullet>().GetSpeed();
		bulletClone.velocity = (Vector3.forward * speed);
		Debug.Log("Slingshot/Fire, clone = " + bulletClone);

		_canFire = false;
		yield return true;
	}
}
