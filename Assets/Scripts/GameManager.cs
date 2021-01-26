﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Cached References")]
    public ParticleSystem partSysWin;

    public GameObject youWinGo;

    [Header("Game State Managers")]
    public static int numOfCorrectOrdersDelivered;
    public static int numOfGameOrdersFinished;

    public int fruitCounter = 0;

    public bool pouredFluid = false;

    private void Start()
    {

    }

    void Update()
    {
        GameWin();
    }

    private void GameWin()
    {
        if (numOfGameOrdersFinished == 3)
        {
            partSysWin.Play();
            // AudioManager.audioManager.PlaySound(SoundTypes.GameWin);
            youWinGo.SetActive(true);
        } 
    }


}
