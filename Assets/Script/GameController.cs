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
    PlayerProperty playerprop;
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
        Menu.SetActive(true);
    }

    public void WinMenu()
    {
        MenuPanel.color = MenuColor;
        for (int i = 0; i < 3; i++)
        {
            MenuText[1].color = VictoryColorOne;
            MenuText[2].color = VictoryColorTwo;
            MenuText[i].text = "Victory!";
        }
        Menu.SetActive(true);
        NextLevelBtn.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Application.Quit();
    }


}