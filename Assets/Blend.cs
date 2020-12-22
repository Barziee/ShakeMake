using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blend : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnMouseDown()
    {
        spawnPoint.Rotate(0f, 180f, 0f);
        Debug.Log("BLENDDDDDD");
    }
}
