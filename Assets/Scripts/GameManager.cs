using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Cached References")]
    public ParticleSystem partSysWin;

    [Header("Game State Managers")]
    public static int numOfCorrectOrdersDelivered;
    public static int numOfGameOrdersFinished;

    void Start()
    {
        
    }


    void Update()
    {
        GameWin();

    }



    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Application.Quit();");
    }


    private void GameWin()
    {
        if (numOfGameOrdersFinished == 3)
        {
            partSysWin.Play();
        } 
    }


}
