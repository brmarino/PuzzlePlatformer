using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	//public string mainGameScene;

	public void StartGame()
	{
		SceneManager.LoadScene("levelOne");
	}

	public void StartLevelTwo()
	{
		SceneManager.LoadScene ("levelTwo");
	}

	public void StartLevelThree()
	{
		SceneManager.LoadScene ("levelThree");
	}	

	public void StartLevelFour()
	{
		SceneManager.LoadScene ("levelFour");
	}	

	public void QuitGame()
	{
		Application.Quit();
	}

}