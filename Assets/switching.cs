using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switching : MonoBehaviour {

	public GameObject avatar1, avatar2;

	int whichAvatarIsOn = 1;

	void Start () {
		avatar1.GetComponent<PlayerController> ().enabled = true;
		avatar2.GetComponent<PlayerController> ().enabled = false;

	}

	void Update () {
		if(Input.GetKeyDown (KeyCode.Tab)){

			SwitchAvatar ();
		}
	}
	public void SwitchAvatar()
	{

		switch (whichAvatarIsOn) {

		case 1:

			whichAvatarIsOn = 2;
			avatar1.GetComponent<PlayerController> ().enabled = false;
			avatar2.GetComponent<PlayerController> ().enabled = true;
			break;

		case 2:
			whichAvatarIsOn = 1;

			avatar1.GetComponent<PlayerController> ().enabled = true;
			avatar2.GetComponent<PlayerController> ().enabled = false;
			break;
		}	
	}
}
