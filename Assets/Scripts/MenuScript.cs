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
        AudioManager.audioManager.PlaySound(SoundTypes.FruitTap);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void EnableMusic()
    {
        yesButton.color = new Color32(224, 92, 147, 255);
        noButton.color = new Color32(60, 60, 60, 255);
        AudioManager.audioManager.PlaySound(SoundTypes.MusicLoop);
    }

    public void DisableMusic()
    {
        AudioManager.audioManager.StopSound(SoundTypes.MusicLoop);
        noButton.color = new Color32(224, 92, 147, 255);
        yesButton.color = new Color32(60, 60, 60, 255);
        
    }

    public void Options()
    {
        AudioManager.audioManager.PlaySound(SoundTypes.FruitTap);
    }

    public void QuitGame()
    {
        AudioManager.audioManager.PlaySound(SoundTypes.FruitTap);
        Application.Quit();
    }


}
