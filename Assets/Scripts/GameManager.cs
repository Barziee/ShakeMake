using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Cached References")]
    public ParticleSystem partSysWin1;
    public ParticleSystem partSysWin2;
    public AudioSource winSound;


    public GameObject youWinGo;

    public Animator youwinAnime;

    [Header("Game State Managers")]
    public static int numOfCorrectOrdersDelivered;
    public static int numOfGameOrdersFinished;

    public int fruitCounter = 0;

    public bool pouredFluid = false;

    public static bool winCondition = false;




    void Update()
    {
        if (numOfGameOrdersFinished == 3 && winCondition)
        {
            winCondition = false;
            StartCoroutine(GameWin());
        }
    }


    private IEnumerator GameWin()
    {
            yield return new WaitForEndOfFrame();
            youWinGo.SetActive(true);
            winSound.Play();
            partSysWin1.Play();
            partSysWin2.Play();
            youwinAnime.SetTrigger("youwinin");
        yield return new WaitForSeconds(0.2f);
    }


}
