using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class instantiator : MonoBehaviour {

	public Object prefab;
	public Transform parent;
	public GameObject animControllerScript;

	// Use this for initialization
	void Start () {
		// Load specific animal
		//loadPrefab(saveManager.Instance.state.petType);
		loadPrefab("petCow_animTest");
		GameObject clone = Instantiate(prefab,parent) as GameObject;
		clone.AddComponent<animatorController>();
		clone.GetComponent<Animator>().runtimeAnimatorController = AssetDatabase.LoadAssetAtPath("Assets/Graphics/Models/animator.controller", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
		//GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//cube.AddComponent<Rigidbody>();
		//cube.transform.position = new Vector3(x, y, 0);

		//Object prefab = AssetDatabase.LoadAssetAtPath("Assets/something.prefab", typeof(GameObject));
		//GameObject clone = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
		// Modify the clone to your heart's content
		//clone.transform.position = Vector3.one;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void loadPrefab(string petType) {
		prefab = AssetDatabase.LoadAssetAtPath("Assets/Graphics/Models/" + petType + ".fbx", typeof(GameObject));
		Debug.Log ("Loaded prefab");
	}
}
