using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Cached References")]
    public ParticleSystem partSysWin;

    [Header("Game State Managers")]
    public static int numOfCorrectOrdersDelivered;
    public static int numOfGameOrdersFinished;
 
    void Update()
    {
        GameWin();
    }

    private void GameWin()
    {
        if (numOfGameOrdersFinished == 3)
        {
            partSysWin.Play();
        } 
    }


}
