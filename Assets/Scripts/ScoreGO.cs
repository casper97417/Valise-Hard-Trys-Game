using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreGO : MonoBehaviour {

	public static int Score;

	public static int test;

	Text text;

	void Awake () {
		text = GetComponent<Text> ();

		Score = PlayerPrefs.GetInt("Score");

		text.text = "Votre score : "+Score;
	}



}
