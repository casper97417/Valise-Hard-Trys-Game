using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewObjectPooler : MonoBehaviour {

	public static NewObjectPooler current;
	public GameObject Rouge;
	public GameObject Bleu;
	private int PooledAmount = 30;

	public List<GameObject> PooledObjects;

	void Awake(){
		current = this;
	}
		
	void Start () {

		PooledObjects = new List<GameObject> ();
		for (int i = 0; i < PooledAmount /3; i++) {
			GameObject obj = (GameObject)Instantiate (Rouge);
			obj.SetActive (false);
			PooledObjects.Add (obj);
		}
		for (int i = 0; i < PooledAmount /3; i++) {
			GameObject obj = (GameObject)Instantiate (Bleu);
			obj.SetActive (false);
			PooledObjects.Add (obj);
		}
	
	}

	public GameObject GetPooledObject(){
		for (int i = Random.Range(0,20); i < PooledObjects.Count; i = Random.Range(0,15))
		{
				if(!PooledObjects[i].activeInHierarchy){
				return PooledObjects[i];
			}
		}



		return null;
	}

	void Update () {
	
	}
}
