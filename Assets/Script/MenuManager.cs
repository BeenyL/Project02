using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    SaveManager savemanager;

    public void playGame()
    {
        savemanager = FindObjectOfType<SaveManager>();
        savemanager.currentLevel = 0;
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void continueGame()
    {
        Save.LoadGame();
        SceneManager.LoadScene(1);
    }

}
