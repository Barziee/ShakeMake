using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{

    public TextMeshProUGUI yesButton;
    public TextMeshProUGUI noButton;
    
    
    void Start()
    {
        EnableMusic();
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void EnableMusic()
    {
        yesButton.color = new Color32(224, 92, 147, 255);
        noButton.color = new Color32(60, 60, 60, 255);
    }

    public void DisableMusic()
    {
        noButton.color = new Color32(224, 92, 147, 255);
        yesButton.color = new Color32(60, 60, 60, 255);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
