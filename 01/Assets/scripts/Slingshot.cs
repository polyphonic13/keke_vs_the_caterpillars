using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	public Rigidbody bullet;
	public GameObject staticBullet;
	
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
	Rigidbody _bulletClone;
	GameObject _staticBulletClone;
	
	// Use this for initialization
	void Awake () {
		Debug.Log("Slingshot/Awake, this position = " + this.transform.position );// + ", parent = " + this.transform.parent.transform.position);
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
			// Debug.Log("Slingshot/Awake, _hasAnimations = " + _hasAnimations + ", _animation = " + _animation + ", _animation[cocked] = " + cockedAnimation.name);
			//_animation.Play(defaultAnimation.name); 
			_animation.Play("ss_default");
			_animation[cockedAnimation.name].speed = cockedAnimationSpeed;
			_animation[fireAnimation.name].speed = fireAnimationSpeed;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
//		if(collected && _hasAnimations) {
			if(Input.GetKeyDown(KeyCode.F)) {
				Debug.Log("Slingshot F key down");
				_canFire = true;
				StartCoroutine(Cock());
			} else if(Input.GetKeyUp(KeyCode.F)) {
				if(_canFire) {
					if(Time.time - _lastFireTime > _fireRepeatTime) {
						_lastFireTime = Time.time;
						/*
						Debug.Log("Slingshot play cocked, _canFire = " + _canFire);
						if(!_canFire) {
							StartCoroutine(Cock());
						} else {
	*/						StartCoroutine(Fire());
							//_animation.Play(cockedAnimation.name);
					// }
						_canFire = false;
					}
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

	public IEnumerator Cock() {
		Debug.Log("cocked = " + cockedAnimation.name);
		if(_staticBulletClone != null) {
			Destroy(_staticBulletClone);
		}
		_animation.Play(cockedAnimation.name);
		float forward = this.transform.position.z - 1.1f;
		float up = this.transform.position.y + 1.2f;
		float right = this.transform.position.x;
		_staticBulletClone = (GameObject) Instantiate(staticBullet, new Vector3(right, up, forward), transform.rotation);
		_canFire = true;
		yield return true;
	}
	
	public IEnumerator Fire() {
		Destroy(_staticBulletClone);

		_animation.Play(fireAnimation.name);
		
		float right = this.transform.position.x;
		float up = this.transform.position.y + 1.2f;
		float forward = this.transform.position.z;
		Rigidbody _bulletClone = (Rigidbody) Instantiate(bullet, new Vector3(right, up, forward), transform.rotation);
		float speed = _bulletClone.GetComponent<SlingshotBullet>().GetSpeed();
		_bulletClone.velocity = (Vector3.forward * speed);
		Debug.Log("Slingshot/Fire, clone = " + _bulletClone);

		_canFire = false;
		yield return true;
	}
}
