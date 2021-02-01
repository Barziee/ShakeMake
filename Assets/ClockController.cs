using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockController : MonoBehaviour
{
	public Image LoadingBar;
	float currentValue;
	public float speed;

	// Update is called once per frame
	void Update()
	{
		if (currentValue < 100)
		{
			currentValue += speed * Time.deltaTime;
		}

		LoadingBar.fillAmount = currentValue / 100;
	}

}
