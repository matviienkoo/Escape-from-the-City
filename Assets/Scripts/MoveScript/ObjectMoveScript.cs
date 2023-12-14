using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMoveScript : MonoBehaviour 
{
	private float clicksPerSecond;
	public bool BoolMove;
	public float TimerMove;

	[Header("Бумага")]
	public Image Img_Object;
	public Sprite[] Sprite_Object;

	[Header("Скорость")]
	public float speed;

	[Header("Рекламный бонус")]
	public bool BoolAdsBonus;

	[Header("Цель до которой движется обьект")]
	public float maxPosLeft;
	private Vector2 originalPos;

	private void Start()
	{
		originalPos = this.transform.localPosition;
		StartCoroutine(TimerTrash());
	}

    IEnumerator TimerTrash()
    {
        yield return new WaitForSeconds(TimerMove);
        BoolMove = true;

        // Возобновить таймер
        StartCoroutine(TimerTrash());
    }

    // Рекламный бонус
    public void AdsBonus ()
    {
        BoolAdsBonus = true;
        StartCoroutine(EnableBonus());
    }
    IEnumerator EnableBonus()
    {
        yield return new WaitForSeconds(45);
        BoolAdsBonus = false;
    }

	private void FixedUpdate()
	{
		clicksPerSecond = PlayerPrefs.GetFloat("clicksPerSecond");

		if (BoolMove == true)
		{	
			if (clicksPerSecond <= 1)
			{
				speed = 0f;
			}
			if (clicksPerSecond >= 2 && BoolAdsBonus == false)
			{
				speed = 5.3f;
			}
			if (clicksPerSecond >= 2 && BoolAdsBonus == true)
			{
				speed = 10.6f;
			}

			transform.Translate(Vector2.left * speed * Time.deltaTime);
	        if (transform.localPosition.x <= maxPosLeft){
		        transform.localPosition = originalPos;
		        BoolMove = false;

		        int RandomInt = Random.Range(0, 4);
		        if (RandomInt == 0){
		        Img_Object.sprite = Sprite_Object[0];
		    	}
		    	if (RandomInt == 1){
		        Img_Object.sprite = Sprite_Object[1];
		    	}
		    	if (RandomInt == 2){
		        Img_Object.sprite = Sprite_Object[2];
		    	}
		    	if (RandomInt == 3){
		        Img_Object.sprite = Sprite_Object[3];
		    	}
	    	}
		}
	}
}