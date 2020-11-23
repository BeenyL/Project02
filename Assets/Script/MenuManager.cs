using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    SaveManager savemanager;
    PlayerProperty playerprop;

    public void playGame()
    {
        savemanager = FindObjectOfType<SaveManager>();
        savemanager.currentLevel = 0;
        savemanager.currentHealth = 300;
        savemanager.currentArmor = 0;
        savemanager.currentMana = 1;
        savemanager.currentAttack = 0;
        SceneManager.LoadScene(1);
    }

    public void saveGame()
    {
        savemanager = FindObjectOfType<SaveManager>();
        playerprop = FindObjectOfType<PlayerProperty>();
        Save.SaveGame(savemanager, playerprop);
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
        savemanager = FindObjectOfType<SaveManager>();
        SaveData saveData = Save.LoadGame();
        savemanager.setData(saveData);
        SceneManager.LoadScene(1);
    }

}
