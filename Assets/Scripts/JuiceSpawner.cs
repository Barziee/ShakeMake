using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceSpawner : MonoBehaviour
{
    public Transform juiceSpawnPoint;
    public GameObject fluidCube;


    void OnMouseDown()
    {
        StartCoroutine(WaitBetweenCubes());
    }


    IEnumerator WaitBetweenCubes()
    {
        for (int i = 0; i < 20; i++)
        {
            var instance = Instantiate(fluidCube, juiceSpawnPoint);
            instance.transform.localPosition = Vector3.zero;
            yield return new WaitForSeconds(0.2f);
        }
    }

}
