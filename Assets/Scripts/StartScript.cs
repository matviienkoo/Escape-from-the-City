using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour 
{	
	private int i;

	[Header("Анимация руки")]
	public Image Img_Hand;
	public Sprite Sprite_Hand_Clasic;
	public Sprite Sprite_Hand_Click;

	[Header("Звуки")]
	public GameObject Music_Clasic;
	public GameObject Sound_ButtonClick;

	[Header("Туториал")]
	public GameObject Tutorial_Panel;
	public int Int_Tutorial;

	[Header("Скрипты")]
	public TranstionScript TRNS_Script;
	public SettingNumbersScript SettNumber_Script;
	public AudioSorceScript Audio_Script;
	public NotificationScript Notification_Script;

	public void StartGame ()
	{
		// Вход на игровую сцену 
		if (i == 0)
		{
			StartCoroutine(IEnumeratorStart());
			Img_Hand.sprite = Sprite_Hand_Click;
			i ++;
		}
	}

	IEnumerator IEnumeratorStart () 
	{
		yield return new WaitForSeconds(0.3f);
		Img_Hand.sprite = Sprite_Hand_Clasic;
		Sound_ButtonClick.SetActive(true);
		Music_Clasic.SetActive(true);
		Audio_Script.Music_On();

		yield return new WaitForSeconds(1f);
		if (Int_Tutorial == 0){
			Notification_Script.Notification_Tutorial();
		}

		TRNS_Script.AllClosed();
	}

	private void Update ()
	{
		Int_Tutorial = PlayerPrefs.GetInt("Int_Tutorial");

		// Обновить жизни есть начало игры
		if (Int_Tutorial == 0)
		{
			SettNumber_Script.ChangeIndicatorsSlider();
		}

		// Проверка пройден ли туториал
		if (Int_Tutorial >= 1)
		{
			Tutorial_Panel.SetActive(false);
		}
	}
}
