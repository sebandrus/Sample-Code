using UnityEngine;
using System.Collections;

[System.Serializable]

public class DamgaeAbility : BasicAbbility {

	[SerializeField] private int _basDam;
	[SerializeField] private ElementEnum _type;

	public ElementEnum Type {
		get {
			return _type;
		}
		set {
			_type = value;
		}
	}

	public int BasDam {
		get {
			return _basDam;
		}
		set {
			_basDam = value;
		}
	}
}
