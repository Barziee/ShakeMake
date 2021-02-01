using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderCheckScript : MonoBehaviour
{
    [Header("Public Cached References")]
    public Transform shakeDropHolderGO;
    public Transform fruitSpawnGO;
    public Animator correctAnimator;
    public GameObject correctGO;
    public Animator incorrectAnimator;
    public GameObject incorrectGO;
    public GameObject glassTopGO;
    public OrderScript orderSC;
    public Blend blendSC;
    public Animator glassAnimator;
    public Sprite[] tubeFillArray = new Sprite[4];
    public Image tubeImage;
    public ParticleSystem niceParticle;

    public int countCorrect = 0;

    public AudioManager audioManager;
    private AudioSource niceSound;
    private AudioSource failSound;

    private Vector3 startPosFail;

    private void Start()
    {
        startPosFail = new Vector3(0f, 11.68f, 14f);
    }


    public void CheckOrder(List<GameObject> list, int orderBubble)
    {
        for (int x = 0; x < list.Count; x++)
        {
            if (blendSC.fruitListBlend.Count < 4)
            {
                Debug.Log("~~~ NOT ENOUGH FRUITS ~~~");

            }
            else if (blendSC.fruitListBlend.Count >= 4)
            {
                if (list[x].tag == blendSC.fruitListBlend[x].tag)
                {
                    Debug.Log("Correct object in spot num: " + x);
                    countCorrect++;
                }
                else
                {
                    Debug.Log("Incorrect object in spot num: " + x);
                }
            }
        }

        if (countCorrect > 3)
        {
            countCorrect = 0;
            Debug.Log("~~~ COUNT CORRECT ~~~ " + countCorrect);
            StartCoroutine(CorrectSequance(orderBubble));
        }

        else if (countCorrect <= 3)
        {

            Debug.Log("~~~ ORDER WAS UNSECCESFULL ~~~");
            GameManager.numOfCorrectOrdersDelivered++;
        }

        if (GameManager.numOfCorrectOrdersDelivered == 3)
        {
            StartCoroutine(IncorrectSequance());
            GameManager.numOfCorrectOrdersDelivered = 0;
        }
        countCorrect = 0;
    }

    private IEnumerator CorrectSequance(int orderBubble)
    {
        Debug.Log("~~~ ORDER DELIVERD SUCCSEFULLY ~~~");
        Debug.Log("Order Bubble To String : " + orderBubble.ToString());
        glassTopGO.SetActive(true);
        AudioManager.audioManager.PlaySound(SoundTypes.WinSound);
        niceParticle.Play();


        switch (orderBubble)
        {
            case 0:
                glassAnimator.SetTrigger("GlassOrder1");

                break;

            case 1:
                glassAnimator.SetTrigger("GlassOrder2");

                break;

            case 2:
                glassAnimator.SetTrigger("GlassOrder3");

                break;

        }

        correctGO.transform.position = startPosFail;

        correctGO.SetActive(true);

        correctAnimator.SetTrigger("winin");

        yield return new WaitForSeconds(3.5f);
        correctGO.SetActive(false);
        yield return new WaitForSeconds(3.5f);
        shakeDropHolderGO.gameObject.SetActive(false);

        foreach (Transform child in shakeDropHolderGO)
        {
            child.position = shakeDropHolderGO.position;
        }

        foreach (Transform child in fruitSpawnGO)
        {
            Destroy(child.gameObject);

        }

        orderSC.orderBubbleList[orderBubble].gameObject.SetActive(false);

        foreach (Transform child in orderSC.ingredientHolder[orderBubble])
        {
            Destroy(child.gameObject);

        }

        orderSC.ordersArray[orderBubble].Clear();
        blendSC.fruitListBlend.Clear();

        yield return new WaitForSeconds(1.5f);

        GameManager.numOfGameOrdersFinished++;

        if (GameManager.numOfGameOrdersFinished == 1)
        {
            //tubeFillArray[0].SetActive(true);
            tubeImage.sprite = tubeFillArray[1];

        }
        else if (GameManager.numOfGameOrdersFinished == 2)
        {
            //tubeFillArray[1].SetActive(true);
            tubeImage.sprite = tubeFillArray[2];

        }
        else if (GameManager.numOfGameOrdersFinished == 3)
        {
            //tubeFillArray[2].SetActive(true);
            tubeImage.sprite = tubeFillArray[3];
            GameManager.winCondition = true;

        }

        GameManager.numOfCorrectOrdersDelivered = 0;

        glassTopGO.SetActive(false);

    }

    private IEnumerator IncorrectSequance()
    {
        incorrectGO.transform.position = startPosFail;

        incorrectGO.SetActive(true);

        incorrectAnimator.SetTrigger("failin");

        AudioManager.audioManager.PlaySound(SoundTypes.LoseSound);

        shakeDropHolderGO.gameObject.SetActive(false);

        foreach (Transform child in shakeDropHolderGO)
        {
            child.position = shakeDropHolderGO.position;
        }

        Debug.Log("~~ NUM OF INCORRECT ORDERS ~~" + GameManager.numOfCorrectOrdersDelivered);

        foreach (Transform child in fruitSpawnGO)
        {
            Destroy(child.gameObject);

        }

        yield return new WaitForSeconds(3.5f);

        incorrectGO.SetActive(false);

        blendSC.fruitListBlend.Clear();

        countCorrect = 0;
        Debug.Log("~~~ COUNT CORRECT ~~~ " + countCorrect);
    }

}
