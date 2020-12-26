using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Blend blend;

    void OnMouseDown()
    {
        var instance = Instantiate(this.gameObject, spawnPoint);
        instance.transform.localPosition = Vector3.zero;
        blend.fruitListBlend.Add(instance.transform);

        Debug.Log("Fruit added");
    }


}
