using UnityEngine;
using System.Collections;

public class PoolObject : MonoBehaviour {

	public float createTime = 2f;
	public float Time = 950f;
	public float ReducTime = 800f;
	public static float speed = 1;

	void create(){
		GameObject obj = NewObjectPooler.current.GetPooledObject();

		if (obj == null)
			return;
		obj.transform.position = new Vector3 (0, 0, 0);
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);

		createTime = 1f;
	}
		
	void Start () {
	
	}

	void Update () {


		Time++;

		if(Time >= 1000){
			Invoke ("create", 0.1f);
			//Time = Random.Range (ReducTime, 900);
			//Time = 840 + (speed * 20.83f); //970 //125
			Time = 960;
		}

		if (ReducTime < 800) {
			//ReducTime = ReducTime + 0.1f;
		}
	
	}
}
