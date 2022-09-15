using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScreen");
        Debug.Log("menu");
    }
    private void Start()
    {
        Cursor.lockState = 0;
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
