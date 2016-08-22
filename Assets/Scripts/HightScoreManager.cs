using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HightScoreManager : MonoBehaviour {

	public static float HightScore=10;

	Text text;

	void Awake () {
		text = GetComponent<Text> ();
		//PlayerPrefs.SetInt ("Meilleur Score", 0);
	}

	void Update () {

		text.text = "Meilleur score : " + PlayerPrefs.GetInt("Meilleur Score");
	
	}
}
