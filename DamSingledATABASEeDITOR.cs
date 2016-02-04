 
using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class DamSingledATABASEeDITOR : EditorWindow {
	private enum State
	{
		BLANK,
		EDIT,
		ADD
	}
	private State state;
	private int selectedAbility;

	private string newAbilityName;
	private int newAbilityBaseDamage;
	private int newAbilitySpeed;
	private int newAbilityCost;
	private int newAbilityAnimation;
	private ElementEnum newAbilityType;

	private const string DATABASE_PATH = @"Assets/Database/DamSinleTarDB.asset";
	private DamSinleTarDatabase Abilities;
	private Vector2 _scrollPos;
	[MenuItem("AngelsFall/Database/Dam Single Tagets Abilities Database %#w")]


	public static void Init() {
		DamSingledATABASEeDITOR window = EditorWindow.GetWindow<DamSingledATABASEeDITOR>();
		window.minSize = new Vector2(800, 400);
		window.Show();
	}
	void OnEnable() {
		if (Abilities == null)
			LoadDatabase();
		state = State.BLANK;
	}
	void OnGUI() {
		EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
		DisplayListArea();
		DisplayMainArea();
		EditorGUILayout.EndHorizontal();
	}
	void LoadDatabase() {
		Abilities = (DamSinleTarDatabase)AssetDatabase.LoadAssetAtPath(DATABASE_PATH, typeof(DamSinleTarDatabase));
		if (Abilities == null)
			CreateDatabase();
	}
	void CreateDatabase() {
		Abilities = ScriptableObject.CreateInstance<DamSinleTarDatabase>();
		AssetDatabase.CreateAsset(Abilities, DATABASE_PATH);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
	}
	void DisplayListArea() {
		EditorGUILayout.BeginVertical(GUILayout.Width(250));
		EditorGUILayout.Space();
		_scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, "box", GUILayout.ExpandHeight(true));
		for (int cnt = 0; cnt < Abilities.COUNT; cnt++)
		{
			EditorGUILayout.BeginHorizontal();
			if (GUILayout.Button("-", GUILayout.Width(25)))
			{
				Abilities.RemoveAt(cnt);
				Abilities.SortAlphabeticallyAtoZ();
				EditorUtility.SetDirty(Abilities);
				state = State.BLANK;
				return;
			}
			if (GUILayout.Button(Abilities.DamSingleTar(cnt).Name, "box", GUILayout.ExpandWidth(true)))
			{
				selectedAbility = cnt;
				state = State.EDIT;
			}
			EditorGUILayout.EndHorizontal();
		}
		EditorGUILayout.EndScrollView();
		EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
		EditorGUILayout.LabelField("Abilities: " + Abilities.COUNT, GUILayout.Width(100));
		if (GUILayout.Button("New Ability"))
			state = State.ADD;
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.Space();
		EditorGUILayout.EndVertical();
	}
	void DisplayMainArea()
	{
		EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
		EditorGUILayout.Space();
		switch (state)
		{
		case State.ADD:
			DisplayAddMainArea();
			break;
		case State.EDIT:
			DisplayEditMainArea();
			break;
		default:
			DisplayBlankMainArea();
			break;
		}
		EditorGUILayout.Space();
		EditorGUILayout.EndVertical();
	}
	void DisplayBlankMainArea()
	{
		EditorGUILayout.LabelField(
			"There are 3 things that can be displayed here.\n" +
			"1) Ability info for editing\n" +
			"2) Black fields for adding a new Ability\n" +
			"3) Blank Area",
			GUILayout.ExpandHeight(true));
	}
	void DisplayEditMainArea()
	{
		Abilities.DamSingleTar(selectedAbility).Name = EditorGUILayout.TextField(new GUIContent("Name: "), Abilities.DamSingleTar(selectedAbility).Name);
		Abilities.DamSingleTar(selectedAbility).BasDam = int.Parse(EditorGUILayout.TextField(new GUIContent("Base Damage: "), Abilities.DamSingleTar(selectedAbility).BasDam.ToString()));
		Abilities.DamSingleTar(selectedAbility).Cost = int.Parse(EditorGUILayout.TextField(new GUIContent("Cost: "), Abilities.DamSingleTar(selectedAbility).Cost.ToString()));
		Abilities.DamSingleTar(selectedAbility).Speed = int.Parse(EditorGUILayout.TextField(new GUIContent("Speed: "), Abilities.DamSingleTar(selectedAbility).Speed.ToString()));
		Abilities.DamSingleTar (selectedAbility).Animation =  int.Parse(EditorGUILayout.TextField(new GUIContent("Animation: "), Abilities.DamSingleTar(selectedAbility).Animation.ToString()));
		Abilities.DamSingleTar (selectedAbility).Type = (ElementEnum)EditorGUILayout.EnumPopup (Abilities.DamSingleTar (selectedAbility).Type);

		EditorGUILayout.Space();
		if (GUILayout.Button("Done", GUILayout.Width(100)))
		{
			Abilities.SortAlphabeticallyAtoZ();
			EditorUtility.SetDirty(Abilities);
			state = State.BLANK;
		}
	}
	void DisplayAddMainArea()
	{
		newAbilityName = EditorGUILayout.TextField(new GUIContent("Name: "), newAbilityName);
		newAbilityBaseDamage = Convert.ToInt32(EditorGUILayout.TextField(new GUIContent("Base Damage: "), newAbilityBaseDamage.ToString()));
		newAbilityCost = Convert.ToInt32(EditorGUILayout.TextField(new GUIContent("Cost: "), newAbilityCost.ToString()));
		newAbilitySpeed = Convert.ToInt32(EditorGUILayout.TextField(new GUIContent("Speed: "), newAbilitySpeed.ToString()));
		newAbilityAnimation =Convert.ToInt32(EditorGUILayout.TextField(new GUIContent("Animation: "), newAbilitySpeed.ToString()));
		newAbilityType = (ElementEnum)EditorGUILayout.EnumPopup (ElementEnum.Air);
		
		EditorGUILayout.Space();
		if (GUILayout.Button("Done", GUILayout.Width(100)))
		{
			Abilities.Add(new DamSingleTar(newAbilityAnimation,newAbilityCost,newAbilitySpeed,newAbilityBaseDamage,newAbilityType,newAbilityName));
			Abilities.SortAlphabeticallyAtoZ();
			newAbilityName = string.Empty;
			newAbilityBaseDamage = 0;
			EditorUtility.SetDirty(Abilities);
			state = State.BLANK;
		}
	}
}
