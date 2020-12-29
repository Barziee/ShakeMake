using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCheckScript : MonoBehaviour
{
    public OrderScript orderSC;
    public Blend blendSC;
    public ParticleSystem partSys;
    private bool correctOrderBool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var countCorrect = 0;

            for (int x = 0; x < orderSC.orderList0.Count - 1; x++)
            {
                if (blendSC.fruitListBlend.Count < 3)
                {
                    Debug.Log("~~~ NOT ENOUGH FRUITS ~~~");

                }
                else if (blendSC.fruitListBlend.Count == 3)
                {
                    if (orderSC.orderList0[x].tag == blendSC.fruitListBlend[x].tag)
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

            if (countCorrect == 3)
            {
                Debug.Log("~~~ ORDER DELIVERD SUCCSEFULLY ~~~");
                partSys.Play();
            }
            else if (countCorrect < 3)
            {
                Debug.Log("~~~ ORDER WAS UNSECCESFULL ~~~");

            }

        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            blendSC.fruitListBlend.Clear();
            orderSC.SetOrder();

        }

    }

}
