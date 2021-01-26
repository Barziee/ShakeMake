using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    public GameManager gmSC;

    public OrderCheckScript ocSC;

    public Blend blendSC;

    public float resetButtonPressSpeed;

    private Vector3 startPos = new Vector3(-3.7f, 3.2f, -7.035f);
    private Vector3 endPos = new Vector3(-3.6f, 2.85f, -7.035f);

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

        StartCoroutine(ResetButtonLerpDown());

    }

    private IEnumerator ResetButtonLerpDown()
    {
        var timeSinceStarted = 0.0f;

        while (true)
        {
            timeSinceStarted += Time.deltaTime;

            transform.localPosition = Vector3.Lerp(transform.localPosition, endPos, timeSinceStarted * resetButtonPressSpeed);

            if (transform.localPosition == endPos)
            {
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        timeSinceStarted = 0.0f;

        while (true)
        {
            timeSinceStarted += Time.deltaTime;

            transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, timeSinceStarted * resetButtonPressSpeed);

            if (transform.localPosition == startPos)
            {
                yield break;
            }
            yield return null;

        }
    }
}
