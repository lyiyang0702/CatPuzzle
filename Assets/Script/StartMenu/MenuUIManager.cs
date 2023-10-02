using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    public AudioSource StartMusic;
    public void StartGame()
    {
        StartMusic.Play();
        LifeTimeBroadCaster.ProceedLevel();
    }

    public void Quit()
    {
        LifeTimeBroadCaster.Quit();
    }

    public void Restart()
    {
        LifeTimeBroadCaster.Restart();
    }
}
