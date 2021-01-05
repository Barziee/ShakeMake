using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Blend blend;

    public AudioManager audioManager;
    public AudioSource fruit_tap;
    

    void OnMouseDown()
    {
        var instance = Instantiate(this.gameObject, spawnPoint);
        instance.transform.localPosition = Vector3.zero;
        blend.fruitListBlend.Add(instance.transform);
        fruit_tap.clip = audioManager.audioClips[0];
        fruit_tap.Play();

        Debug.Log("Fruit added");
    }


}
