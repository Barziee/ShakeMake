﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCheckScript : MonoBehaviour
{
    [Header("Public Cached References")]
    public Transform shakeDropHolderGO;
    public Transform fruitSpawnGO;
    public GameObject correctGO;
    public GameObject incorrectGO;
    public GameObject glassTopGO;
    public OrderScript orderSC;
    public Blend blendSC;
    public Animator glassAnimator;

    int countCorrect = 0;

    public void CheckOrder(List<GameObject> list, int orderBubble)
    {
        for (int x = 0; x < list.Count; x++)
        {
            if (blendSC.fruitListBlend.Count < 4)
            {
                Debug.Log("~~~ NOT ENOUGH FRUITS ~~~");

            }
            else if (blendSC.fruitListBlend.Count >= 4)
            {
                if (list[x].tag == blendSC.fruitListBlend[x].tag)
                {
                    Debug.Log("Correct object in spot num: " + x);
                    countCorrect++;

                }
                else
                {
                    Debug.Log("Incorrect object in spot num: " + x);

                }

            }

        }

        if (countCorrect > 3)
        {
            countCorrect = 0;
            Debug.Log("~~~ COUNT CORRECT ~~~ " + countCorrect);

            StartCoroutine(CorrectSequance(orderBubble));

        }

        else if (countCorrect <= 3)
        {
            Debug.Log("~~~ ORDER WAS UNSECCESFULL ~~~");
            GameManager.numOfCorrectOrdersDelivered++;

        }

        if (GameManager.numOfCorrectOrdersDelivered == 3)
        {
            StartCoroutine(IncorrectSequance());
            GameManager.numOfCorrectOrdersDelivered = 0;

        }

        countCorrect = 0;

    }

    private IEnumerator CorrectSequance(int orderBubble)
    {
        Debug.Log("~~~ ORDER DELIVERD SUCCSEFULLY ~~~");

        Debug.Log("Order Bubble To String : " + orderBubble.ToString());

        glassTopGO.SetActive(true);

        switch (orderBubble)
        {
            case 0:
                glassAnimator.SetTrigger("GlassOrder1");

                break;

            case 1:
                glassAnimator.SetTrigger("GlassOrder2");

                break;

            case 2:
                glassAnimator.SetTrigger("GlassOrder3");

                break;

        }

        correctGO.SetActive(true);

        yield return new WaitForSeconds(1.2f);

        correctGO.SetActive(false);

        yield return new WaitForSeconds(3f);

        shakeDropHolderGO.gameObject.SetActive(false);

        foreach (Transform child in shakeDropHolderGO)
        {
            child.position = shakeDropHolderGO.position;
        }

        foreach (Transform child in fruitSpawnGO)
        {
            Destroy(child.gameObject);

        }

        orderSC.orderBubbleList[orderBubble].gameObject.SetActive(false);

        foreach (Transform child in orderSC.ingredientHolder[orderBubble])
        {
            Destroy(child.gameObject);

        }

        orderSC.ordersArray[orderBubble].Clear();
        blendSC.fruitListBlend.Clear();

        yield return new WaitForSeconds(1.5f);

        GameManager.numOfGameOrdersFinished++;

        GameManager.numOfCorrectOrdersDelivered = 0;

        glassTopGO.SetActive(false);

    }

    private IEnumerator IncorrectSequance()
    {
        incorrectGO.SetActive(true);

        shakeDropHolderGO.gameObject.SetActive(false);

        foreach (Transform child in shakeDropHolderGO)
        {
            child.position = shakeDropHolderGO.position;
        }

        Debug.Log("~~ NUM OF INCORRECT ORDERS ~~" + GameManager.numOfCorrectOrdersDelivered);

        foreach (Transform child in fruitSpawnGO)
        {
            Destroy(child.gameObject);

        }

        yield return new WaitForSeconds(1.5f);

        incorrectGO.SetActive(false);

        blendSC.fruitListBlend.Clear();

        countCorrect = 0;
        Debug.Log("~~~ COUNT CORRECT ~~~ " + countCorrect);

    }

}
