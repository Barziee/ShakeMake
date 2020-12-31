using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCheckScript : MonoBehaviour
{
    [Header("Public Cached References")]
    public Transform shakeDropHolderGO;
    public Transform fruitSpawnGO;
    public GameObject correctGO;
    public GameObject incorrectGO;
    public OrderScript orderSC;
    public Blend blendSC;

    int countCorrect = 1;

    public void CheckOrder(List<GameObject> list)
    {
        for (int x = 0; x < list.Count; x++)
        {
            if (blendSC.fruitListBlend.Count < 3)
            {
                Debug.Log("~~~ NOT ENOUGH FRUITS ~~~");

            }
            else if (blendSC.fruitListBlend.Count >= 3)
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

        if (countCorrect >= 3)
        {
            StartCoroutine(CorrectSequance());

        }
        else if (countCorrect < 3)
        {
            Debug.Log("~~~ ORDER WAS UNSECCESFULL ~~~");
            GameManager.numOfCorrectOrdersDelivered++;

        }

        if (GameManager.numOfCorrectOrdersDelivered == 3)
        {
            GameManager.numOfCorrectOrdersDelivered = 0;
            StartCoroutine(IncorrectSequance());

        }

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

    }

    private IEnumerator CorrectSequance()
    {
        Debug.Log("~~~ ORDER DELIVERD SUCCSEFULLY ~~~");
        countCorrect = 0;
        Debug.Log("~~~ COUNT CORRECT ~~~ " + countCorrect);

        correctGO.SetActive(true);

        shakeDropHolderGO.gameObject.SetActive(false);

        foreach (Transform child in shakeDropHolderGO)
        {
            child.position = shakeDropHolderGO.position;
        }

        foreach (Transform child in fruitSpawnGO)
        {
            Destroy(child.gameObject);

        }


        blendSC.fruitListBlend.Clear();

        yield return new WaitForSeconds(1.5f);

        correctGO.SetActive(false);

        GameManager.numOfGameOrdersFinished++;

        GameManager.numOfCorrectOrdersDelivered = 0;

    }

}
