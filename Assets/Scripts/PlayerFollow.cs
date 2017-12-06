using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {

    // Assign public player transforms for the camera to attach itself to
    public Transform Player1;
    public Transform Player2;

    // The currently active player
    private int ActivePlayer;


    // Use this for initialization
    void Start () {
        // Set Player1 to the currently active player
        ActivePlayer = 1;	
	}
	
	// Update is called once per frame
	void Update () {

        // Change the currently active player when "TAB" is pressed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(ActivePlayer == 1)
            {
                ActivePlayer = 2;
            }
            else
            {
                ActivePlayer = 1;
            }
        }

        // If ActivePlayer = 1, follow Player1 and vise versa
        if (ActivePlayer == 1)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = Player1.position.x;
            newPosition.y = Player1.position.y;
            transform.position = newPosition;
        }
        else
        {
            Vector3 newPosition = transform.position;
            newPosition.x = Player2.position.x;
            newPosition.y = Player2.position.y;
            transform.position = newPosition;
        }

	}
}
