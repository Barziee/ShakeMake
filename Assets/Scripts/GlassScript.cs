using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassScript : MonoBehaviour
{
    [Header("Public Cached References")]
    public OrderCheckScript orderCheckSC;
    public OrderScript orderSC;
    public GameManager gmSC;

    private List<GameObject> currentListCheck;

    private void OnMouseDown()
    {
        for (int i = 0; i < 3; i++)
        {
            currentListCheck = orderSC.ordersArray[i];

            orderCheckSC.CheckOrder(currentListCheck, i);

            gmSC.pouredFluid = false;

            gmSC.fruitCounter = 0;
        }

    }

}
