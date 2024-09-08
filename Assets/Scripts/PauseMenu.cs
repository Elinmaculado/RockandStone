using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Awake()
    {
        pauseMenu.SetActive(false);
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
    }

    public void UnPauseGame()
    { 
        pauseMenu.SetActive(false); 
    }

}
