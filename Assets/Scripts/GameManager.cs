using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public static int count;

	public int P1Life;
	public int P2Life;
	public Text countText;          //Store a reference to the UI Text component which will display the number of pickups collected.
	public Text winText;   

	public GameObject p1Wins;
	public GameObject p2Wins;

	public GameObject[] p1Sticks;
	public GameObject[] p2Sticks;

	public AudioSource hurtSound;

	public string mainMenu;

	// Use this for initialization

	void Start () {
		count = 0;
		winText.text = "";

	}

	// Update is called once per frame

	void Update () {
		if(P1Life <= 0)
		{
			player1.SetActive(false);
			p2Wins.SetActive(true);
		}

		if(P2Life <= 0)
		{
			player2.SetActive(false);
			p1Wins.SetActive(true);
		}

		if(Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene(mainMenu);
		}
	}

	public void HurtP1()
	{
		//P1Life -= 1;

		//for(int i = 0; i < p1Sticks.Length; i++)
		//{
		//	if(P1Life > i)
		//	{
		//		p1Sticks[i].SetActive(true);
		//	} else {
		//		p1Sticks[i].SetActive(false);
		//	}
		//}

		hurtSound.Play();
	}

	public void HurtP2()
	{
		//P2Life -= 1;

		//for(int i = 0; i < p2Sticks.Length; i++)
		//{
		//	if(P2Life > i)
		//	{
		//		p2Sticks[i].SetActive(true);
		//	} else {
		//		p2Sticks[i].SetActive(false);
		//	}
		//}

		hurtSound.Play();
	}

public void SetCountText()
{
	//Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
	countText.text = "Count: " + count.ToString ();

	//Check if we've collected all 12 pickups. If we have...
	if (count >= 3){
		//... then set the text property of our winText object to "You win!"
		winText.text = "You win!";
		SceneManager.LoadScene("MenuScreen");
	}
}
}