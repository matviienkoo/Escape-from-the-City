using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaltikaMoveScript : MonoBehaviour 
{
	private float clicksPerSecond;
	public GameObject Baltika_GameObject;
	public Button ButtonBaltika;
	public bool BoolMoveBaltika;

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
	}

    public void LaunchBaltika()
    {
    	BoolMoveBaltika = true;
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

		if (BoolMoveBaltika == true)
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
		        BoolMoveBaltika = false;
		        Baltika_GameObject.SetActive(false);
		        ButtonBaltika.enabled = true;
	    	}
		}
	}
}