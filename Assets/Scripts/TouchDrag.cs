using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TouchDrag : TouchSprite {

	private bool Touch = false;
	private int Direction = 0;

	private int Life;

	public float Position1; //Toucher initial
	public float Position2; //Déplacement du toucher
	public float PositionFinale; //Distance entre les deux touches *** sensibilité tactile ***



	// Use this for initialization
	void Start () {
		Life = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if (Touch == false) {
			this.transform.Translate (Vector3.down * PoolObject.speed * Time.deltaTime);
		}
		TouchInput (GetComponent<BoxCollider2D> ());
		if (Direction == 1) {
			
			this.transform.Translate (Vector3.left * (PoolObject.speed+5) * Time.deltaTime);
		}
		if (Direction == 2) {
			
			this.transform.Translate (Vector3.right * (PoolObject.speed+5) * Time.deltaTime);
		}

		if (Life <= 0) {
			if (PlayerPrefs.GetInt ("Meilleur Score") < ScoreManager.Score) {
				PlayerPrefs.SetInt ("Meilleur Score", ScoreManager.Score);
			}
			PlayerPrefs.SetInt ("Score", ScoreManager.Score);
			SceneManager.LoadScene ("GameOver");
		}
		
	}



	/*void OnFirstTouch (){

		if (PoolObject.speed <= 6) {

			PoolObject.speed = PoolObject.speed + 0.04f;
		}

		if (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position).x > 0 && Direction == 0 && TouchSprite.PositionFinale >= 2) {
				Direction = 1;
				Touch = true;
			}
		if (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position).x < 0 && Direction == 0 && TouchSprite.PositionFinale <= 2) {
				Direction = 2;
				Touch = true;
			}

	}*/

	void OnFirstTouchBegan(){
		Position1 = Input.GetTouch (0).deltaPosition.x;

		if (PoolObject.speed <= 5.8f) {

			PoolObject.speed = PoolObject.speed + .1f;

		}

	}

	void OnFirstTouchEnded(){


	}

	void OnFirstTouchMoved(){
		Position2 = Input.GetTouch (0).deltaPosition.x;
		PositionFinale = Position2 + Position1;


		if (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position).x > 0 && Direction == 0 && PositionFinale >= 2) {
			Direction = 2;
			Touch = true;
		}
		if (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position).x < 0 && Direction == 0 && PositionFinale <= -2) {
			Direction = 1;
			Touch = true;
		}
	}



	void OnCollisionEnter2D (Collision2D col){
		/*if (col.gameObject.tag == "Bac") {
			
		}*/

		if (col.gameObject.tag == "BacRouge" && this.gameObject.tag == "Rouge" || col.gameObject.tag == "BacBleu" && this.gameObject.tag == "Bleu") {
			
			this.gameObject.SetActive (false);
			Touch = false;
			Direction = 0;
			ScoreManager.Score++;
		}else if (col.gameObject.tag == "BacRouge" && this.gameObject.tag == "Bleu" || col.gameObject.tag == "BacBleu" && this.gameObject.tag == "Rouge" || col.gameObject.tag == "Bac")
			Life--;


	}
		
}
