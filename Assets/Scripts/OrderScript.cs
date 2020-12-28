using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderScript : MonoBehaviour
{
    [Header("Fruit Prefab Cached References")]
    public List<GameObject> fruitList = new List<GameObject>();
    public GameObject Watermelon0;
    public GameObject Apple1;
    public GameObject Peach2;
    public GameObject Strawberry3;
    public GameObject Cherry4;
    public GameObject Banana5;

    [Header("Fluid Prefab Cached References")]
    public List<GameObject> fluidList = new List<GameObject>();
    public GameObject Milk0;
    public GameObject Orange1;

    [Header("Order Bubble Chached References")]
    public Transform ingredientHolder;
    public float spawnOffset = 0.2f;
    public float eulerRot;
    public GameObject milkCartonPre;
    public GameObject juiceCartonPre;

    [Header("~ Current Order List ~")]
    public List<GameObject> orderList0 = new List<GameObject>();

    private GameObject currentFruitToDraw;

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

        SetOrderBubble();

    }

    private void SetOrderBubble()
    {
        foreach (Transform child in ingredientHolder)
        {
            Destroy(child.gameObject);

        }

        Debug.Log("~~~ LIST ONE ~~~");
        Debug.Log(orderList0[0].ToString());
        Debug.Log(orderList0[1].ToString());
        Debug.Log(orderList0[2].ToString());
        Debug.Log(orderList0[3].ToString());

        for (int i = 0; i < orderList0.Count; i++)
        {
            // If Fruits.
            if (i <= 2)
            {
                // This GameObject holds the correct fruit from the order list.
                currentFruitToDraw = orderList0[i].gameObject;

                InstantiateObjectForOrder(i);

            }
            // If Fluids.
            if (i == 3)
            {
                // If MilkCube, instantiate milk carton prefab.
                if (orderList0[3].name == "MilkCube")
                {
                    currentFruitToDraw = milkCartonPre;

                    InstantiateObjectForOrder(i);

                }

                // If JuiceCube, instantiate juice carton prefab.
                if (orderList0[3].name == "JuiceCube")
                {
                    currentFruitToDraw = juiceCartonPre;

                    InstantiateObjectForOrder(i);

                }

            }

        }

    }

    private void InstantiateObjectForOrder(int i)
    {
        // Intantiate the correct fruit, in the future parent's position.
        var instance = Instantiate(currentFruitToDraw, ingredientHolder.position, Quaternion.identity);

        // Set instance parent.
        instance.transform.SetParent(ingredientHolder);

        // Manage the physics for the object (turn all physics off).
        instance.GetComponent<Collider>().enabled = false;
        instance.GetComponent<Rigidbody>().isKinematic = false;
        instance.GetComponent<Rigidbody>().useGravity = false;

        // Set the correct position to the object, multiplied by 'for' loop itaretion.
        instance.GetComponent<Transform>().localPosition = new Vector3(spawnOffset * i, 0f, 0f);
        instance.GetComponent<Transform>().localRotation = Quaternion.Euler(eulerRot, 0f, 0f);
    }
}
