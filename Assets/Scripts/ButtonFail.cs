using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour {

	//Game
	//print ("ButtonManagement");
	public void PlayGame()
	{
			Debug.Log("SceneManager");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}
	
	public void BackBtn (string back)
	{
		SceneManager.LoadScene (back);
	}

	public void RestartBtnAreana (string Restart)
	{
		SceneManager.LoadScene (Restart);
	}

	//Main Menu
	public void NewGameBtn(string newgame)
	{
		SceneManager.LoadScene (newgame);
	}

	public void Controls(string ControlScreen)
	{
		SceneManager.LoadScene (ControlScreen);
	}

	public void ExitGameBtn()
	{
		//Debug.log ("Quit Game");
		Application.Quit();
	}
}
