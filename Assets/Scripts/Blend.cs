using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Blend : MonoBehaviour
{
    public Transform spawnPoint;
    public Rigidbody rb;
    public List<Transform> fruitListBlend = new List<Transform>();



    private void OnMouseDown()
    {
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
