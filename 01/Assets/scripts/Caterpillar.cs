using UnityEngine;
using System.Collections;

public class Caterpillar : Enemy {
	
	public AnimationClip defaultAnimation;
	public AnimationClip walkAnimationLower;
	public AnimationClip walkAnimationUpper;
	public AnimationClip attackAnimationUpper;
	
	public float walkSpeed = 1;
	
	private bool _hasAnimations = false;
	private Animation _animation;
	// Use this for initialization
	
	public void InitAnimations() {
		_animation = GetComponent<Animation>();

		if(defaultAnimation != null && walkAnimationLower != null && walkAnimationUpper != null && attackAnimationUpper != null) {
			_hasAnimations = true;
			_animation.Play(defaultAnimation.name);

			_animation[walkAnimationLower.name].speed = walkSpeed;
	
			_animation[walkAnimationUpper.name].speed = walkSpeed;
			_animation[walkAnimationUpper.name].wrapMode = WrapMode.Once;
			_animation[walkAnimationUpper.name].blendMode = AnimationBlendMode.Additive;
			_animation[walkAnimationUpper.name].layer = 10;
			
			_animation[attackAnimationUpper.name].wrapMode = WrapMode.Once;
			_animation[attackAnimationUpper.name].blendMode = AnimationBlendMode.Additive;
			_animation[attackAnimationUpper.name].layer = 10;
			
		}

	}

	public void HandleAnimations() {
		if(_hasAnimations) {
			_animation.Play(walkAnimationLower.name);

			if(ProximityCheck()) {
				_animation.Play(attackAnimationUpper.name);
			} else {
				_animation.Play(walkAnimationUpper.name);
			}
		}
	}
	
	public void HandleMovement() {
		var playerPos = FindPlayer();
		//Debug.Log("Caterpillar/HandleMovement, playerPos = " + playerPos);
	}
	
	void Awake () {
		Init();
		InitAnimations();
	}

	// Update is called once per frame
	void Update () {
		if(LifeCheck()) {
			HandleAnimations();
			HandleMovement();
		}
	}
}
