using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int Score;

	Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();

		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {


		text.text = ""+Score;

		
	}
}
