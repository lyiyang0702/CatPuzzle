using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;

public class LifeTimeManager : MonoBehaviour
{
    public AudioSource StartMusic;
    public AudioSource BackgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        LifeTimeBroadCaster.OnNextLevelEvent += NextLevel;
        LifeTimeBroadCaster.OnQuit += Quit;
        LifeTimeBroadCaster.OnRestart += Restart;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Arcade Hard Reset
        { 
            HardReset();   
        }
    }

    private void NextLevel(Object o, EventArgs eventArgs)
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Cannot Proceed Next Scene, Max Level Reached. You shouldn't be here");
            SceneManager.LoadScene(0); 
        }
        else
        {
            if (StartMusic)
            {
                StartMusic.Stop();
            }

            BackgroundMusic.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void HardReset()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Index");
    }

    private void Quit(Object o, EventArgs eventArgs)
    {
        Application.Quit();
    }    
    
    private void Restart(Object o, EventArgs eventArgs)
    {
        HardReset();
    }
    
}
