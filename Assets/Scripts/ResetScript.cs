using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public GameManager gmSC;

    public OrderCheckScript ocSC;

    public Blend blendSC;

    private void OnMouseDown()
    {
        gmSC.fruitCounter = 0;

        gmSC.pouredFluid = false;

        blendSC.fruitListBlend.Clear();

        ocSC.countCorrect = 0;

        foreach (Transform child in ocSC.fruitSpawnGO)
        {
            Destroy(child.gameObject);

        }

        ocSC.shakeDropHolderGO.gameObject.SetActive(false);

        foreach (Transform child in ocSC.shakeDropHolderGO)
        {
            child.position = ocSC.shakeDropHolderGO.position;
        }


    }

}
