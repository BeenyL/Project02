using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmManager : MonoBehaviour
{
    [SerializeField] AudioClip normalbgm;
    [SerializeField] AudioClip bossbgm;
    [SerializeField] AudioClip deathbgm;
    [SerializeField] AudioSource audio;
    [SerializeField] Enemy[] enemy;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            enemy[i] = FindObjectOfType<Enemy>();
        }
    }

    public void playbgm()
    {
        for (int i = 0; i < 3; i++)
        {
            enemy[i] = FindObjectOfType<Enemy>();
        }

        if (enemy[0]._isBoss == true || enemy[1]._isBoss == true || enemy[2]._isBoss == true)
        {
            audio.clip = bossbgm;
            audio.Play();
        }

        if (enemy[0]._isBoss == false && enemy[1]._isBoss == false && enemy[2]._isBoss == false)
        {
            audio.clip = normalbgm;
            audio.Play();
        }
    }

    public void playDeathbgm()
    {
        audio.clip = deathbgm;
        audio.Play();
    }
}
