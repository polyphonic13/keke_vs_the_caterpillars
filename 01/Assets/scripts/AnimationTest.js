public var defaultAnimation: AnimationClip;

public var cockedAnimation: AnimationClip;
public var fireAnimation: AnimationClip;

private var _animation: Animation;

function Awake () {
	// _animation = GetComponent(Animation);
	_animation = this.gameObject.GetComponent(Animation);
	if(!_animation) {
		Debug.Log("no animation found for slingshot");
	}
	if(!defaultAnimation) {
		_animation = null;
	}
	if(!cockedAnimation) {
		_animation = null;
	}
	if(!fireAnimation) {
		_animation = null;
	}
	
	var list = GetAnimationNames(_animation);
	Debug.Log("animations = " + list + ", number = " + list.length);
	// Debug.Log("AnimationTest/Awake, _animation = " + _animation + ", cocked = " + cockedAnimation + ", fire = " + fireAnimation + ", default = " + defaultAnimation);
	// _animation[defaultAnimation.name].wrapMode = WrapMode.Once;
	// _animation.Play(defaultAnimation.name);
}

function Update () {
	if(_animation != null) {
	
		if(Input.GetKey(KeyCode.G)) {
			_animation[cockedAnimation.name].wrapMode = WrapMode.Once;
			_animation.Play(cockedAnimation.name);
		}
		if(Input.GetKey(KeyCode.F)) {
			_animation[fireAnimation.name].wrapMode = WrapMode.Once;
			_animation.Play(fireAnimation.name);
		}
	}
}

function GetAnimationNames(anim: Animation) {
	// make an Array that can grow
	var tmpList : Array = new Array();
 
	// enumerate all states
	for (var state : AnimationState in anim) {
		// add name to tmpList
		//tmpList.Add(state.name);
		tmpList.push(state.name);
	}
	// convert to (faster) buildin array (but can't grow anymore)
	// var list : string[] = tmpList.ToBuildin(string);
	// return list;
	return tmpList;
}