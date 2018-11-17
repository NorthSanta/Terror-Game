using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pause;
    public GameObject SettingsBut;

    public GameObject optionsPanel;
    public GameObject journalPanel;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input_Manager.StartButton())
        {
            pause.SetActive(!pause.activeSelf);
            Camera_Control.paused = !Camera_Control.paused;
        }

        if (Input.GetKeyDown(KeyBindings.keys["Pause"]))
        {
            if (pause.activeInHierarchy)
            {
                if (optionsPanel.activeInHierarchy)
                {
                    optionsPanel.SetActive(false);
                }
                else
                {
                    pause.SetActive(false);
                    Camera_Control.paused = false;
                }
            }
            else if (journalPanel.activeInHierarchy)
            {
                journalPanel.SetActive(false);
                Camera_Control.paused = false;
            }
            else
            {
                pause.SetActive(true);
                Camera_Control.paused = true;
            }
        }

        if (Input.GetKeyDown(KeyBindings.keys["Journal"]))
        {
            if (journalPanel.activeInHierarchy)
            {
                journalPanel.SetActive(false);
                Camera_Control.paused = false;
            }
            else
            {
                journalPanel.SetActive(true);
                Camera_Control.paused = true;
            }
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        Camera_Control.paused = false;
    }

    public void Settings()
    {
        //pause.SetActive(false);
        SettingsBut.SetActive(true);
    }

    public void MainMenu()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
