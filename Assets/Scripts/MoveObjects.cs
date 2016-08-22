using UnityEngine;
using System.Collections;

public class MoveObjects : MonoBehaviour {

	public float Speed;
	// Use this for initialization
	void Start () {
		Speed = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.Translate (Vector3.down * 1 * Time.deltaTime);

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;

			transform.Translate (touchDeltaPosition.x * Speed, 0, 0);
		}
	}
}
