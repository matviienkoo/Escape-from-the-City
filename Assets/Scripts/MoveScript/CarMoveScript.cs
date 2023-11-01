using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMoveScript : MonoBehaviour 
{
	private float clicksPerSecond;
	public GameObject Car_GameObject;
	public bool BoolMoveCar;

	[Header("Скорость")]
	public float speed;

	[Header("Цель до которой движется обьект")]
	public float maxPosRight;
	private Vector2 originalPos;

	private void Start()
	{
		originalPos = this.transform.localPosition;
	}

    public void LaunchCar()
    {
    	BoolMoveCar = true;
    }

	private void FixedUpdate()
	{
		clicksPerSecond = PlayerPrefs.GetFloat("clicksPerSecond");

		if (BoolMoveCar == true)
		{
			if (clicksPerSecond <= 1)
			{
				speed = 1f;
			}
			if (clicksPerSecond >= 2)
			{
				speed = 0.2f;
			}

			transform.Translate(Vector2.right * speed * Time.deltaTime);
	        if (transform.localPosition.x >= maxPosRight){
		        transform.localPosition = originalPos;
		        BoolMoveCar = false;
		        Car_GameObject.SetActive(false);
	    	}
		}
	}
}