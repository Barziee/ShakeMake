using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCheckScript : MonoBehaviour
{
    [Header("Public Cached References")]
    public OrderScript orderSC;
    public Blend blendSC;
    public ParticleSystem partSys;
    public GameObject correctGO;
    public GameObject incorrectGO;


    private void Update()
    {

    }

    public void CheckOrder(List<GameObject> list)
    {
        var countCorrect = 0;
        var countIncorrect = 0;

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

        if (countCorrect == 4)
        {
            Debug.Log("~~~ ORDER DELIVERD SUCCSEFULLY ~~~");
            correctGO.SetActive(true);
            countIncorrect--;

        }
        else if (countCorrect < 4)
        {
            Debug.Log("~~~ ORDER WAS UNSECCESFULL ~~~");
            Debug.Log(countIncorrect);

            if (countIncorrect == -1)
            {
                incorrectGO.SetActive(true);

            }

        }

    }

}
