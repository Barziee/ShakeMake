using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Cached References")]
    public ParticleSystem partSysWin;

    [Header("Game State Managers")]
    public static int numOfCorrectOrdersDelivered;
    public static int numOfGameOrdersFinished;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfGameOrdersFinished == 3)
        {
            partSysWin.Play();

        }
        
    }

}
