using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonsController : MonoBehaviour
{
    public GameObject pauseMenu;

    public void OnClickPauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnClickResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

}
