using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

	public static int Life;

	public static AsyncOperation GO;

	Text text;

	// Use this for initialization
	void Awake () {

		text = GetComponent<Text> ();
		Life = 1;
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Vies : " + Life;

		if (Life <= 0) {
			if (PlayerPrefs.GetInt ("Meilleur Score") < ScoreManager.Score) {
				PlayerPrefs.SetInt ("Meilleur Score", ScoreManager.Score);
			}
			PlayerPrefs.SetInt ("Score", ScoreManager.Score);
			SceneManager.LoadScene ("GameOver");
		}
	}
}
