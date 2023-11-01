using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmbulanceMoveScript : MonoBehaviour 
{
	private float clicksPerSecond;
	public GameObject Ambulance_GameObject;
	public bool BoolMoveAmbulance;

	[Header("Скорость")]
	public float speed;

	[Header("Полицейская машина")]
	public Image Img_Car;
	public Sprite Sprite_Car_Ambulance;
	public Sprite Sprite_Car_Police;

	[Header("Полицейский стол")]
	public Image Img_Table;
	public Sprite Sprite_Table_Ambulance;
	public Sprite Sprite_Table_Police;

	[Header("Анимация колес")]
	public Animator Animator_First_Wheel;
	public Animator Animator_Second_Wheel;

	[Header("Цель до которой движется обьект")]
	public float maxPosRight;
	private Vector2 originalPos;

	private void Start()
	{
		originalPos = this.transform.localPosition;
	}

	public void PoliceVariantCar ()
	{
		Img_Car.sprite = Sprite_Car_Police;
	}

	public void PoliceVariantTable ()
	{
		Img_Table.sprite = Sprite_Table_Police;
	}

	private void AmbulanceVariant ()
	{
		Img_Car.sprite = Sprite_Car_Ambulance;
		Img_Table.sprite = Sprite_Table_Ambulance;
	}

    public void LaunchAmbulanceF_Target()
    {
    	// Включить скорую помощь
    	Ambulance_GameObject.SetActive(true);

    	// Запустить движение
    	BoolMoveAmbulance = true;
    	maxPosRight = 3f;

    	// Запустить колеса
    	Animator_First_Wheel.enabled = true;
		Animator_Second_Wheel.enabled = true;
    }

    public void LaunchAmbulanceS_Target()
    {
    	// Запустить движение
    	BoolMoveAmbulance = true;
    	maxPosRight = 358f;

    	// Запустить колеса
    	Animator_First_Wheel.enabled = true;
		Animator_Second_Wheel.enabled = true;
    }


	private void FixedUpdate()
	{
		clicksPerSecond = PlayerPrefs.GetFloat("clicksPerSecond");

		if (BoolMoveAmbulance == true)
		{
			if (clicksPerSecond <= 1)
			{
				speed = 2f;
			}
			if (clicksPerSecond >= 2)
			{
				speed = 0.4f;
			}

			transform.Translate(Vector2.right * speed * Time.deltaTime);
	        if (transform.localPosition.x >= maxPosRight){
		        Animator_First_Wheel.enabled = false;
		        Animator_Second_Wheel.enabled = false;
		        BoolMoveAmbulance = false;

		        if (maxPosRight >= 358f)
		        {
		        	transform.localPosition = originalPos;
		        	AmbulanceVariant();

		        	Ambulance_GameObject.SetActive(false);
		        	BoolMoveAmbulance = false;
		        }
	    	}
		}
	}
}