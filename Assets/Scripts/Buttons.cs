using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

	public static AsyncOperation play;
	public static AsyncOperation quit;

	public GameObject Main;
	public GameObject Quit;

	public void LoadLevel(){
		play = SceneManager.LoadSceneAsync (1, LoadSceneMode.Single);
		PoolObject.speed = 1;
	}

	public void QuitGame(){
		quit = SceneManager.LoadSceneAsync (0, LoadSceneMode.Single);
		PoolObject.speed = 1;
	}

	public void QuitApp(){
		Application.Quit();
	}

	public void SeeQuitCanvas(){
		Main.SetActive (false);
		Quit.SetActive (true);
	}

	public void SeeMainCanvas(){
		Main.SetActive (true);
		Quit.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		Main.SetActive (true);
		Quit.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
