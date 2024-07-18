using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneload : MonoBehaviour
{
    public void Gamestart()
    {
        Debug.Log("1");
        SceneManager.LoadScene(1);
        Debug.Log("GameStart");
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Debug.Log("ReStart");
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Menu");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
