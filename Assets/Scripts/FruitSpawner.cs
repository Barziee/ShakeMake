using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitSpawner : MonoBehaviour
{
    public GameManager gmSC;
    public Transform spawnPoint;
    public Blend blend;



    void OnMouseDown()
    {
        if (!gmSC.pouredFluid && gmSC.fruitCounter <= 2)
        {
            var instance = Instantiate(this.gameObject, spawnPoint);
            instance.transform.localPosition = Vector3.zero;
            blend.fruitListBlend.Add(instance.transform);
            AudioManager.audioManager.PlaySound(SoundTypes.FruitTap);

            Debug.Log("Fruit added");

            gmSC.fruitCounter++;

        }

    }

}
