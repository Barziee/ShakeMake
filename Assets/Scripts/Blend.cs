﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Blend : MonoBehaviour
{
    [Header("Public Cached References")]
    public Transform spawnPoint;
    public GameObject blenderTopGO;
    public GameObject shakeParticlesGO;
    public Rigidbody rb;

    [Header("Fruit List In Blender")]
    public List<Transform> fruitListBlend = new List<Transform>();

    private void OnMouseDown()
    {
        blenderTopGO.SetActive(true);
        shakeParticlesGO.SetActive(true);

        Debug.Log(fruitListBlend.Count);
        for (var i = 0; i < fruitListBlend.Count; i++)
        {
            fruitListBlend[i].GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Fruit added");
        }

        rb.AddTorque(0f, 9000f, 0f, ForceMode.Force);
        Debug.Log("BLENDDDDDD");
    }
}
