using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OmonMoveScript : MonoBehaviour 
{
	private float clicksPerSecond;
	public NotificationScript NoticeScript;
	public int StepInt;

	[Header("Система омона")]
	public GameObject Omon_GameObject;
	public bool BoolOmon;

	[Header("Омоновцы")]
	public Image Omon_First;
	public ImageAnimator Script_Omon_First;
	public Image Omon_Second;
	public ImageAnimator Script_Omon_Second;
	public Image Omon_Thirt;
	public ImageAnimator Script_Omon_Thirt;
	public Sprite Omon_Clasic;

	[Header("Полицейская машина")]
	public GameObject Dead_Object;
	public GameObject Flasher_Object;
	public DeadScript KillScript;
	public AmbulanceMoveScript AmbulanceScript;

	[Header("Скорость")]
	public float speed;

	[Header("Цель до которой движется обьект")]
	public float maxPos;
	private Vector2 originalPos;

	private void Start()
	{
		originalPos = this.transform.localPosition;
	}

    public void LaunchOmon()
    {
    	BoolOmon = true;
    }

    public void DisableOmon()
    {
    	Omon_GameObject.SetActive(false);
    }

	private void FixedUpdate()
	{
		clicksPerSecond = PlayerPrefs.GetFloat("clicksPerSecond");

		// Омон бежит 
		if (BoolOmon == true)
		{
			if (clicksPerSecond <= 1){
				speed = 0.8f;
			}
			if (clicksPerSecond >= 2 && clicksPerSecond < 3){
				speed = 0.5f;
			}
			if (clicksPerSecond >= 3 && StepInt < 400){
				speed = 0f;
				StepInt += 1;
			}

			if (clicksPerSecond >= 4 && StepInt >= 400){
				speed = -0.1f;
				StepInt += 1;
			}

			transform.Translate(Vector2.right * speed * Time.deltaTime);
	        if (transform.localPosition.x >= 200){
	        	// Омоновцы перестают бежать
	        	Script_Omon_First.enabled = false;
	        	Omon_First.sprite = Omon_Clasic;
	        	Script_Omon_Second.enabled = false;
	        	Omon_Second.sprite = Omon_Clasic;
	        	Script_Omon_Thirt.enabled = false;
	        	Omon_Thirt.sprite = Omon_Clasic;

	        	// Запускается сцена смерты
	        	Dead_Object.SetActive(true);
	        	Flasher_Object.SetActive(true);
	        	AmbulanceScript.PoliceVariantTable();

	        	// Выключается бег
	        	BoolOmon = false;
	    	}

	    	if (transform.localPosition.x <= -45){
	    		NoticeScript.Notification_Omon();
	        	BoolOmon = false;
	        	DisableOmon();
	    	}
		}
	}
}