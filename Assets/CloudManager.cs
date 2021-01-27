using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CloudMover();

    }

    private void CloudMover()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, -Vector3.forward, 1 * Time.deltaTime);
    }
}
