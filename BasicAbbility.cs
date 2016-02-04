using UnityEngine;
using System.Collections;

[System.Serializable]

public class BasicAbbility {
	[SerializeField] private int _animation;
	[SerializeField] private int _cost;
	private int _level;
	[SerializeField] private float _speed;
	[SerializeField] private string _name;

	public string Name {
		get {
			return _name;
		}
		set {
			_name = value;
		}
	}

	public float Speed {
		get {
			return _speed;
		}
		set {
			_speed = value;
		}
	}

	public int Animation {
		get {
			return _animation;
		}
		set {
			_animation = value;
		}
	}

	public int Cost {
		get {
			return _cost;
		}
		set {
			_cost = value;
		}
	}

	public int Level {
		get {
			return _level;
		}
		set {
			_level = value;
		}
	}
}
