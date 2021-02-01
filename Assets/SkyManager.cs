using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    public Material[] skyMatsArray = new Material[3];

    void Start()
    {
        StartCoroutine(SkyLerp());
        Debug.Log("SkyManagerON!");

    }

    private IEnumerator SkyLerp()
    {
        RenderSettings.skybox = skyMatsArray[0];
        Debug.Log("MORNING");
        yield return new WaitForSeconds(50f);
        RenderSettings.skybox = skyMatsArray[1];
        Debug.Log("NOON");
        yield return new WaitForSeconds(30f);
        RenderSettings.skybox = skyMatsArray[2];
        Debug.Log("EVENING");
    }


}
