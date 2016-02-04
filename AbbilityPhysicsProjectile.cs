using UnityEngine;
using System.Collections;

[RequireComponent (typeof( SphereCollider))]
[RequireComponent (typeof( Rigidbody))]
public class AbbilityPhysicsProjectile : MonoBehaviour {
	private Transform me;
	private BasicAbbility data;
	private Rigidbody phy;

	public BasicAbbility Data {
		get {
			return data;
		}
		set {
			data = value;
		}
	}

	// Use this for initialization
	void Start () {
		me = transform;
		phy = me.gameObject.GetComponent<Rigidbody> ();

		Vector3 speed = (me.forward * data.Speed * 100);
		phy.AddForce(speed);
	
	}

	
	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerEnter(Collider other){
		Debug.Log (other.name);
		if (other.CompareTag ("Terrain") || other.CompareTag ("Player"))
						return;

		if (other.CompareTag ("Mob")) {
			Debug.Log (data);
			if( data is DamSingleTar)
						(data as DamSingleTar).Effect ((other.gameObject).GetComponent<MobAI> ().Data);
			else
				Debug.Log ("MOMO");
				}
		Destroy (me.gameObject);
	}
}
