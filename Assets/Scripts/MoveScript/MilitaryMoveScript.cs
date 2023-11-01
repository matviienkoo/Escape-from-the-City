using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MilitaryMoveScript : MonoBehaviour 
{
	private float clicksPerSecond;
	private int IntOne;

	public bool BoolMove;
	public GameObject Ivent_GameObject;
	public GameObject Soldier_Object;
	public IventScript Ivent_Script;
	public EventSystem EventFunction;
	public NotificationScript Notification_Script;

	[Header("Скорость")]
	public float speed;

	[Header("Цель до которой движется обьект")]
	public float maxPosLeft;
	public float maxPosLeftFinal;
	private Vector2 originalPos;

	private void Start()
	{
		originalPos = this.transform.localPosition;
	}

    public void Launch ()
    {
    	BoolMove = true;
    }

    IEnumerator WaitText () 
	{
		yield return new WaitForSeconds(6f);
		Notification_Script.Notification_Military();
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
			if (clicksPerSecond >= 2)
			{
				speed = 5.3f;
			}

			transform.Translate(Vector2.left * speed * Time.deltaTime);
			
			// Первая точка
	        if (transform.localPosition.x <= 3){
        	if (IntOne == 0){
        		EventFunction.enabled = false;
        		clicksPerSecond = 0;
        		PlayerPrefs.SetFloat("clicksPerSecond", clicksPerSecond);
        		
		        Soldier_Object.SetActive(true);
		        StartCoroutine(WaitText());
		        IntOne ++;
	    	}
		    }

		    // Вторая точка
		    if (transform.localPosition.x <= maxPosLeftFinal){
	        if (maxPosLeftFinal <= -278){
	        	transform.localPosition = originalPos;
	        	Ivent_GameObject.SetActive(false);
	        	BoolMove = false;
	        }
		    }
		}
	}
}