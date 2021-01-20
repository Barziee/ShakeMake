using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{

    public TextMeshProUGUI yesButton;
    public TextMeshProUGUI noButton;

    public AudioManager audioManager;
    public AudioSource music;
    public AudioSource tap;


    void Start()
    {
        EnableMusic();
    }


    public void PlayGame()
    {
        tap.clip = audioManager.audioClips[0];
        tap.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void EnableMusic()
    {
        yesButton.color = new Color32(224, 92, 147, 255);
        noButton.color = new Color32(60, 60, 60, 255);
        music.clip = audioManager.audioClips[4];
        music.Play();
    }

    public void DisableMusic()
    {
        noButton.color = new Color32(224, 92, 147, 255);
        yesButton.color = new Color32(60, 60, 60, 255);
        music.clip = audioManager.audioClips[4];
        music.Stop();
    }

    public void Options()
    {
        tap.clip = audioManager.audioClips[0];
        tap.Play();   
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
