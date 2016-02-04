using UnityEngine;
using System.Collections;

[System.Serializable]

public class DamSingleTar : DamgaeAbility {

	public DamSingleTar(int a,int c,int s,int bd, ElementEnum t,string n){
		Level = 0;
		Animation = a;
		Cost = c;
		Speed = s;
		BasDam = bd;
		Type = t;
		Name = n;
		}

	public void Effect(BaseCharector t){
		Debug.Log ("Spell Hit");
		t.Vitals[(int)VariableStatNameEnum.Health].CurValue =t.Vitals[(int)VariableStatNameEnum.Health].CurValue  - BasDam;
		Debug.Log (t.Vitals [(int)VariableStatNameEnum.Health].CurValue + " / " + t.Vitals [(int)VariableStatNameEnum.Health].MaxValue);
	}
}
