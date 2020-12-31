using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Blend : MonoBehaviour
{
    [Header("Public Cached References")]
    public Transform fruitSpawnGO;
    public GameObject blenderTopGO;
    public GameObject shakeParticlesGO;
    public Rigidbody rb;
    public Animator blenderAnimator;

    [Header("Fruit List In Blender")]
    public List<Transform> fruitListBlend = new List<Transform>();

    private void OnMouseDown()
    {
        StartCoroutine(StartBlenderLoop());
    }

    private IEnumerator StartBlenderLoop()
    {
        blenderTopGO.SetActive(true);
        shakeParticlesGO.SetActive(true);

        Debug.Log("" + fruitListBlend.Count.ToString());

        for (var i = 0; i < fruitListBlend.Count; i++)
        {
            fruitListBlend[i].GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            fruitListBlend[i].GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Fruit added");

        }

        rb.AddTorque(0f, 9000f, 0f, ForceMode.Force);
        Debug.Log("BLENDDDDDD");

        yield return new WaitForSeconds(4f);

        foreach (Transform child in fruitSpawnGO) 
        {
            child.gameObject.SetActive(false);

        }

        rb.AddTorque(0f, 0f, 0f, ForceMode.VelocityChange);

        yield return new WaitForSeconds(0.6f);

        blenderTopGO.SetActive(false);

        blenderAnimator.SetTrigger("Pour");

    }

}

