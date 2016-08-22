using UnityEngine;
using System.Collections;

public class DestroyObj : MonoBehaviour {

	void OnEnable(){
		Invoke ("Destroy", 20f);
	}

	void Destroy(){
		gameObject.SetActive (false);
	}

	void OnDisable(){
		CancelInvoke();
	}
}
