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
    public GameObject milkCartonPre;
    public GameObject juiceCartonPre;
    public Transform fruitSpawnerGO;
    public List<Transform> ingredientHolder;

    [Header("Order Bubble Spawn Variables")]
    public float spawnOffset = 0.2f;
    public float eulerRot;

    [Header("~ Order Lists ~")]
    public List<GameObject> orderList0 = new List<GameObject>();
    public List<GameObject> orderList1 = new List<GameObject>();
    public List<GameObject> orderList2 = new List<GameObject>();

    private List<GameObject>[] ordersArray = new List<GameObject>[3];
    private List<GameObject> currentList;
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

        ordersArray[0] = orderList0;
        ordersArray[1] = orderList1;
        ordersArray[2] = orderList2;

        for (int x = 0; x < ordersArray.Length; x++)
        {
            currentList = ordersArray[x];

            SetOrder(currentList);

        }

    }

    public void SetOrder(List<GameObject> list)
    {
        for (int i = 0; i < 3; i++)
        {

            var tmpFruit = Random.Range(0, 6);
            list.Add(fruitList[tmpFruit]);

        }

        var tmpFluid = Random.Range(0, 2);
        list.Add(fluidList[tmpFluid]);

        SetOrderBubble(currentList);

    }

    private void SetOrderBubble(List<GameObject> list)
    {
        Debug.Log("~~~ LIST NAME: " + list.ToString() + " ~~~");
        Debug.Log(list[0].ToString());
        Debug.Log(list[1].ToString());
        Debug.Log(list[2].ToString());
        Debug.Log(list[3].ToString());

        if (list == orderList0)
        {
            CheckWhichFruitToSpawn(list, ingredientHolder[0]);

        }
        else if (list == orderList1)
        {
            CheckWhichFruitToSpawn(list, ingredientHolder[1]);

        }
        else if (list == orderList2)
        {
            CheckWhichFruitToSpawn(list, ingredientHolder[2]);

        }

    }

    private void CheckWhichFruitToSpawn(List<GameObject> list, Transform ingredient)
    {
        for (int i = 0; i < list.Count; i++)
        {
            // If Fruits.
            if (i <= 2)
            {
                // This GameObject holds the correct fruit from the order list.
                currentFruitToDraw = list[i].gameObject;

                InstantiateObjectForOrder(i, ingredient);

            }
            // If Fluids.
            if (i == 3)
            {
                // If MilkCube, instantiate milk carton prefab.
                if (list[3].name == "MilkCube")
                {
                    currentFruitToDraw = milkCartonPre;

                    InstantiateObjectForOrder(i, ingredient);

                }

                // If JuiceCube, instantiate juice carton prefab.
                if (list[3].name == "JuiceCube")
                {
                    currentFruitToDraw = juiceCartonPre;

                    InstantiateObjectForOrder(i, ingredient);

                }

            }

        }
    }

    private void InstantiateObjectForOrder(int i, Transform ingredient)
    {
        // Intantiate the correct fruit, in the future parent's position.
        var instance = Instantiate(currentFruitToDraw, ingredient.position, Quaternion.identity);

        // Set instance parent.
        instance.transform.SetParent(ingredient);

        // Manage the physics for the object (turn all physics off).
        instance.GetComponent<Collider>().enabled = false;
        instance.GetComponent<Rigidbody>().isKinematic = false;
        instance.GetComponent<Rigidbody>().useGravity = false;

        // Set the correct position to the object, multiplied by 'for' loop itaretion.
        instance.GetComponent<Transform>().localPosition = new Vector3(spawnOffset * i, 0f, 0f);
        instance.GetComponent<Transform>().localRotation = Quaternion.Euler(eulerRot, 0f, 0f);

    }

}
