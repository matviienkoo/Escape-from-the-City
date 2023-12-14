using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PoliceMoveScript : MonoBehaviour 
{
	private float clicksPerSecond;
	public EventSystem EventFunction;

	[Header("Система полиции")]
	public GameObject Police_GameObject;
	public bool BoolMovePolice;
	public bool BoolBackMovePolice;

	[Header("Система омона")]
	public GameObject Omon_GameObject;
	public OmonMoveScript OmonScript;

	[Header("Скорость")]
	public float speed;

	[Header("Анимация колес")]
	public Animator Animator_First_Wheel;
	public Animator Animator_Second_Wheel;

	[Header("Рекламный бонус")]
	public bool BoolAdsBonus;

	[Header("Система текста")]
	public TextMeshProUGUI Text_Police;
	private int IntText;

	[Header("Цель до которой движется обьект")]
	public float maxPos;
	private Vector2 originalPos;

	private void Start()
	{
		originalPos = this.transform.localPosition;
	}

	IEnumerator IEnumerator_Text () 
	{
	    var originalString = Text_Police.text;
	    Text_Police.text = "";

	    var numCharsRevealed = 0;
	    while (numCharsRevealed < originalString.Length)
	    {
	        ++numCharsRevealed;
	        Text_Police.text = originalString.Substring(0, numCharsRevealed);
	        if (Text_Police.text == originalString){
	        yield return new WaitForSeconds(2f);
	        Changes_Text();
	    	}
	        yield return new WaitForSeconds(0.07f);
        }
    }

    private void Changes_Text ()
    {
    	IntText += 1;

    	if (IntText == 4){
    	Text_Police.text = "";

    	// Машина едет назад
    	LaunchPolice_Leave();

    	// Побежали омоновцы
    	StartOmon();

    	// Появилась возможность бежать
    	EventFunction.enabled = true;
    	}

    	if (IntText == 3){
    	Text_Police.text = "Вот же гнида..";
    	StartCoroutine(IEnumerator_Text());
    	}

    	if (IntText == 2){
    	Text_Police.text = "САДИСЬ В МАШИНУ";
    	StartCoroutine(IEnumerator_Text());
    	}

    	if (IntText == 1){
    	Text_Police.text = "Садись в машину";
    	StartCoroutine(IEnumerator_Text());
    	}
    }

    public void LaunchPolice_Come()
    {
    	// Включить скорую помощь
    	Police_GameObject.SetActive(true);

    	// Запустить движение
    	BoolMovePolice = true;

    	// Запустить колеса
    	Animator_First_Wheel.enabled = true;
		Animator_Second_Wheel.enabled = true;
    }

    public void LaunchPolice_Leave()
    {
    	BoolBackMovePolice = true;
    }

    public void StartOmon()
    {
    	Omon_GameObject.SetActive(true);
    	OmonScript.LaunchOmon();
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

		// Машина идет вперед
		if (BoolMovePolice == true)
		{
			if (clicksPerSecond <= 1 && BoolAdsBonus == false)
			{
				speed = 2f;
			}
			if (clicksPerSecond >= 2 && BoolAdsBonus == false)
			{
				speed = 0.4f;
			}

			if (clicksPerSecond <= 1 && BoolAdsBonus == true)
			{
				speed = 1f;
			}
			if (clicksPerSecond >= 2 && BoolAdsBonus == true)
			{
				speed = 0.2f;
			}

			transform.Translate(Vector2.right * speed * Time.deltaTime);
	        if (transform.localPosition.x >= 0){
		        Animator_First_Wheel.enabled = false;
		        Animator_Second_Wheel.enabled = false;
		        EventFunction.enabled = false;
		        BoolMovePolice = false;
		        Changes_Text();
	    	}
		}

		// Машина едет назад
		if (BoolBackMovePolice == true)
		{
			if (clicksPerSecond <= 1 && BoolAdsBonus == false)
			{
				speed = 0f;
			}
			if (clicksPerSecond >= 2 && BoolAdsBonus == false)
			{
				speed = 5.3f;
			}

			if (clicksPerSecond <= 1 && BoolAdsBonus == true)
			{
				speed = 0f;
			}
			if (clicksPerSecond >= 2 && BoolAdsBonus == true)
			{
				speed = 10.6f;
			}

			transform.Translate(Vector2.left * speed * Time.deltaTime);
			if (transform.localPosition.x <= -435){
	    		transform.localPosition = originalPos;
	        	Police_GameObject.SetActive(false);
	        	BoolBackMovePolice = false;
	    	}
		}
	}
}