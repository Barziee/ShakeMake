using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderScript : MonoBehaviour
{
    public List<GameObject> fruitList = new List<GameObject>();
    public GameObject Watermelon0;
    public GameObject Apple1;
    public GameObject Peach2;
    public GameObject Strawberry3;
    public GameObject Cherry4;
    public GameObject Banana5;

    public List<GameObject> fluidList = new List<GameObject>();
    public GameObject Milk0;
    public GameObject Orange1;

    public List<GameObject> orderList0 = new List<GameObject>();

    void Start()
    {
        fruitList.Add(Watermelon0);
        fruitList.Add(Apple1);
        fruitList.Add(Peach2);
        fruitList.Add(Strawberry3);
        fruitList.Add(Cherry4);
        fruitList.Add(Banana5);

        fluidList.Add(Milk0);
        fluidList.Add(Orange1);

        SetOrder();

    }

    public void SetOrder()
    {
        orderList0.Clear();

        for (int i = 0; i < 3; i++)
        {

            var tmpFruit = Random.Range(0, 6);
            orderList0.Add(fruitList[tmpFruit]);

        }

        var tmpFluid = Random.Range(0, 2);
        orderList0.Add(fluidList[tmpFluid]);

        Debug.Log("~~~ LIST ONE ~~~");
        Debug.Log(orderList0[0].ToString());
        Debug.Log(orderList0[1].ToString());
        Debug.Log(orderList0[2].ToString());
        Debug.Log(orderList0[3].ToString());

    }

}
