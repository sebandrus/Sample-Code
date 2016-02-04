using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DamSinleTarDatabase : ScriptableObject {
	[SerializeField] private List<DamSingleTar> database;
	
	void OnEnable() {
		if( database == null )
			database = new List<DamSingleTar>();
	}
	
	public void Add( DamSingleTar abb ) {
		database.Add( abb );
	}
	
	public void Remove( DamSingleTar abb ) {
		database.Remove( abb );
	}
	
	public void RemoveAt( int index ) {
		database.RemoveAt( index );
	}
	
	public int COUNT {
		get { return database.Count; }
	}
	
	//.ElementAt() requires the System.Linq
	public DamSingleTar DamSingleTar( int index ) {
		return database.ElementAt( index );
	}
	
	public void SortAlphabeticallyAtoZ() {
		database.Sort((x, y) => string.Compare(x.Name, y.Name));
	}
}
