using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//make sure to add a eventsystem with a standalone input module!! (buttons wont work otherwise)

public class BtnManager : MonoBehaviour
{
  public void ModeBtn (string ModeScene)
  {
    SceneManager.LoadScene(ModeScene);
  }
  public void PlayGameBtn (string NewSceneName)
  {
  	SceneManager.LoadScene(NewSceneName);
  }

  public void ControlBtn (string ContrlBtnScene)
  {
  	SceneManager.LoadScene(ContrlBtnScene);
  }

  public void BackBtn (string BackBtn)
  {
    SceneManager.LoadScene(BackBtn);
  }

  public void ExitBtn ()
  {
  	Application.Quit();
  }
}
