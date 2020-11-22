using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text[] MenuText;
    [SerializeField] GameObject Menu;
    [SerializeField] Image MenuPanel;
    [SerializeField] Button NextLevelBtn;
    [SerializeField] Color DiedColor;
    [SerializeField] Color MenuColor;
    [SerializeField] Color VictoryColorOne;
    [SerializeField] Color VictoryColorTwo;

    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip lose;

    PlayerProperty playerprop;
    SaveManager savemanager;
    SaveData savedata;
    bool esc;
    //restart / quit
    private void Awake()
    {
        playerprop = FindObjectOfType<PlayerProperty>();
        NextLevelBtn.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            esc = !esc;
            if (esc == true && playerprop._isDead == false)
            {
                MenuPanel.color = MenuColor;
                for (int i = 0; i < 3; i++)
                {
                    MenuText[i].text = "Menu";
                }
                Menu.SetActive(true);
            }
            else
            {
                Menu.SetActive(false);
            }
        }
    }

    public void DeathMenu()
    {
        MenuPanel.color = DiedColor;
        for (int i = 0; i < 3; i++)
        {
            MenuText[i].text = "Game Over!";
        }
        audio.PlayOneShot(lose);
        Menu.SetActive(true);
    }

    public void WinMenu()
    {
        savemanager = FindObjectOfType<SaveManager>();
        savemanager.currentLevel++;
        Save.SaveGame(savemanager);
        MenuPanel.color = MenuColor;
        for (int i = 0; i < 3; i++)
        {
            MenuText[1].color = VictoryColorOne;
            MenuText[2].color = VictoryColorTwo;
            MenuText[i].text = "Victory!";
        }
        audio.PlayOneShot(win);
        Menu.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        savemanager = FindObjectOfType<SaveManager>();
        savemanager.currentLevel = 0;
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }


}