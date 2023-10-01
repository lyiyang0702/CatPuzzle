using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    public void StartGame()
    {
        LifeTimeBroadCaster.ProceedLevel();
    }

    public void Quit()
    {
        LifeTimeBroadCaster.Quit();
    }
}
