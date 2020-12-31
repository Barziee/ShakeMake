using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceSpawner : MonoBehaviour
{
    public Transform juiceSpawnPoint;
    public GameObject fluidCube;
    public Blend blend;

    void OnMouseDown()
    {
        StartCoroutine(WaitBetweenCubes());
    }

    IEnumerator WaitBetweenCubes()
    {
        for (int i = 0; i < 15; i++)
        {
            var instance = Instantiate(fluidCube, juiceSpawnPoint);
            instance.transform.localPosition = Vector3.zero;
            blend.fruitListBlend.Add(instance.transform);
            yield return new WaitForSeconds(0.2f);
        }

    }

}
