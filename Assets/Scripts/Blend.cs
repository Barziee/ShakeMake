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

    public ParticleSystem dust;
    public float buttonPressSpeed;

    private Vector3 targetPos;
    private Vector3 startPos;

    private void Start()
    {
        startPos = new Vector3(-3.7f, 3.2f, -3.37f);
        targetPos = new Vector3(-3.6f, 2.85f, -3.37f);
    }

    private void OnMouseDown()
    {
        StartCoroutine(StartBlenderLoop());
        StartCoroutine(BlendButtonLerp());
    }

    private IEnumerator BlendButtonLerp()
    {
        var timeSinceStarted = 0.0f;

        while (true)
        {
            timeSinceStarted += Time.deltaTime;

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, timeSinceStarted * buttonPressSpeed);

            if (transform.position == targetPos)
            {
                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator StartBlenderLoop()
    {
        blenderTopGO.SetActive(true);
        shakeParticlesGO.SetActive(true);
        CreateDust();
        AudioManager.audioManager.PlaySound(SoundTypes.Blender);

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

        StartCoroutine(BlendButtonLerpUp());

        blenderTopGO.SetActive(false);

        blenderAnimator.SetTrigger("Pour");

    }

    private IEnumerator BlendButtonLerpUp()
    {
        var timeSinceStarted = 0.0f;

        while (true)
        {
            timeSinceStarted += Time.deltaTime;

            transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, timeSinceStarted * buttonPressSpeed);

            if (transform.position == startPos)
            {
                yield break;
            }
            yield return null;
        }
    }

    void CreateDust()
    {
        dust.Play();
    }

}

