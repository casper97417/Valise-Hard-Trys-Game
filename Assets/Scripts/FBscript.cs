using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Facebook.Unity;
using UnityEngine.UI;
using System.Linq;

public class FBscript : MonoBehaviour {

	public GameObject DialogLoggedIn;
	public GameObject DialogLoggedOut;
	//public GameObject DialogUsername;
	//public GameObject DialogProfilePic;

	void Awake(){
		FB.Init (SetInit, OnHideUnity);
	}

	void SetInit(){
		if (FB.IsLoggedIn) {
			Debug.Log ("FB is logged in");
		} else {
			Debug.Log ("FB is not logged in");
		}
		DealWithFBMenus (FB.IsLoggedIn);
	}

	void OnHideUnity(bool isGameShown){
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void FBlogin(){
		List<string> permissions = new List<string> ();
		permissions.Add ("public_profile");

		FB.LogInWithReadPermissions (permissions, AuthCallBack);
	}
	void AuthCallBack(IResult result){
		if (result.Error != null) {
			Debug.Log (result.Error);
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is logged in");
			} else {
				Debug.Log ("FB is not logged in");
			}
			DealWithFBMenus (FB.IsLoggedIn);
		}
	}

	void DealWithFBMenus(bool isLoggedIn){ // aparaitre/disparaitre le boutton de connection (Login)
		if (isLoggedIn) {
			DialogLoggedIn.SetActive (true);
			DialogLoggedOut.SetActive (false);

			/*FB.API ("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
			FB.API ("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);*/

		} else {
			DialogLoggedIn.SetActive (false);
			DialogLoggedOut.SetActive (true);
		}
	}

	/*void DisplayUsername(IResult result){
		Text UserName = DialogUsername.GetComponent<Text> ();

		if (result.Error == null) {
			UserName.text = "Hi there, " + result.ResultDictionary ["first_name"];
		} else {
			Debug.Log (result.Error);
		}
	}

	void DisplayProfilePic(IGraphResult result){
		if (result.Texture != null) {
			Image ProfilePic = DialogProfilePic.GetComponent<Image> ();

			ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
		} else {
			
		}
	}*/
		
	public void ShareWithFriends(){
		FB.FeedShare (string.Empty,
                    new Uri("https://developers.facebook.com/"),
			"I've make a great score : "+ PlayerPrefs.GetInt("Score"),
                    "Test caption",
                    "Test Description",
                    new Uri("http://i.imgur.com/zkYlB.jpg"),
                    string.Empty);
	}

	public void InviteFriends(){
		FB.AppRequest (
			message: "this game is awesome, join me. now.",
			title: "Invite your friends to join you"

		);
	}
}
