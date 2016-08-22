using UnityEngine;
using System.Collections;

public class DragingScript : MonoBehaviour {

	public GameObject gameObjectToDrag;

	public Vector3 GOcenter; // Centre du GameObject
	public Vector3 TouchPosition; // Position du clic ou toucher
	public Vector3 Offset; //Vecteur entre le point touché/clic de souris et le centre de l'objet
	public Vector3 newGoCenter; // Le nouveau centre du GameObjet

	RaycastHit hit; //store hit object information, information de l'objet par le rayon

	public bool dragingeMode = false; //si le déplacement est en cours
	public bool CanMoove = true; //Si le mouvement est permit ou non

	public int LR = 0;// Left/Right, la direction choisie par l'utilisateur



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*Le mouvement ne se se produit qu'a l'arrivée du réceptacle
		Le mouvement peut être modifié jusuq'au dernier moment*/

		Vector3 LFT = transform.TransformDirection(Vector3.left);
		Vector3 RHT = transform.TransformDirection(Vector3.right);

		if (LR == 1) {// direction choisie
			if (Physics.Raycast (transform.position, LFT, 10f)) { //Un rayon (raycast) vérifie s'il y a un collider dans la direction
				//print ("Il y a qq chose a gauche de l'objet");
				this.transform.Translate (Vector3.left * 1 * Time.deltaTime);//Mouvement de l'objet en cas de présence d'un collider
				CanMoove = false; // le mouvement n'est plus permis une fois une direction prise par l'objet
			}
		}

		if (LR == 2) {
			if (Physics.Raycast (transform.position, RHT, 10f)) {
				//print ("Il y a qq chose a droite de l'objet");
				this.transform.Translate (Vector3.right * 1 * Time.deltaTime);
				CanMoove = false;
			}
		}

		if(CanMoove)
		this.transform.Translate (Vector3.down * 1 * Time.deltaTime);


		//*********************
		//*** CLICK TO DRAG ***
		//*********************


		#if UNITY_EDITOR // Uniquement dans l'éditeur Unity (à supprimer dans le rendu final)

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				gameObjectToDrag = hit.collider.gameObject;
				GOcenter = gameObjectToDrag.transform.position;
				TouchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Offset = TouchPosition - GOcenter;
				dragingeMode = true;
			}
		}

		if (Input.GetMouseButton (0)) {
		if (dragingeMode && CanMoove) {
				TouchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				newGoCenter = TouchPosition - Offset;

				if(newGoCenter.x <= -2){
					LR = 1;
				}

				if(newGoCenter.x >= 2){
					LR = 2;
				}
				//gameObjectToDrag.transform.position = new Vector3 (newGoCenter.x, newGoCenter.y, GOcenter.z);
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			dragingeMode = false;
		}
#endif



		//*********************
		//*** TOUCH TO DRAG ***
		//*********************
		foreach(Touch touch in Input.touches){
			switch (touch.phase) {
				//when just touch
			case TouchPhase.Began:
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				//if ray hit a collider (not 2DCollider)
				if (Physics.SphereCast(ray, 0.03f, out hit)){
					gameObjectToDrag = hit.collider.gameObject;
					GOcenter = gameObjectToDrag.transform.position;
					TouchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					Offset = TouchPosition - GOcenter;
					dragingeMode = true;
				}
				break;

			case TouchPhase.Moved:
				if (dragingeMode && CanMoove){
					TouchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					newGoCenter = TouchPosition - Offset;

					if(newGoCenter.x <= -2){ //Le mouvement doit avoir au moins deux pixels de différence avec la position d'orrigine pour éviter les erreures
						LR = 1;
					}

					if(newGoCenter.x >= 2){
						LR = 2;
					}
				}
				break;

			case TouchPhase.Ended:
				dragingeMode = false;
				break;
			}
		}
	}
	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Bac") {
			this.gameObject.SetActive (false);
			CanMoove = true;
			LR = 0;
		}
	}
	
}
