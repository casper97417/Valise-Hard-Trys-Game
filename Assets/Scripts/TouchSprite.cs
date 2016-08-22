using UnityEngine;
using System.Collections;

public class TouchSprite : MonoBehaviour {

	public static bool GuiTouch = false;

	public void TouchInput (Collider2D collider){
		if (Input.touchCount > 0) {
			if (collider == Physics2D.OverlapPoint (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position))) {
				switch (Input.GetTouch (0).phase) {
				case TouchPhase.Began:
					SendMessage ("OnFirstTouchBegan", SendMessageOptions.DontRequireReceiver);
					SendMessage ("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
					GuiTouch = true;
					break;
				case TouchPhase.Stationary:
					SendMessage ("OnFirstTouchStayed", SendMessageOptions.DontRequireReceiver);
					SendMessage ("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
					GuiTouch = true;
					break;
				case TouchPhase.Moved:
					SendMessage ("OnFirstTouchMoved", SendMessageOptions.DontRequireReceiver);
					SendMessage ("OnFirstTouch", SendMessageOptions.DontRequireReceiver);
					GuiTouch = true;
					break;
				case TouchPhase.Ended:
					SendMessage ("OnFirstTouchEnded", SendMessageOptions.DontRequireReceiver);
					GuiTouch = false;
					break;
				case TouchPhase.Canceled:
					SendMessage ("OnFirstTouchCanceled", SendMessageOptions.DontRequireReceiver);
					GuiTouch = false;
					break;
				}
			}
		}
	}
}
