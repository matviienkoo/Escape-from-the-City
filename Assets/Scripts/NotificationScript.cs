using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class NotificationScript : MonoBehaviour 
{
	public TextMeshProUGUI Text_Notification;
	public Animation Text_Anim;
	public EventSystem EventFunction;
	private int IntText;

	[Header("Обьекты для туториала")]
	public GameObject Tutorial_Panel;
	public Animation Tutorial_Anim;
	public Animation Upper_Anim;
    public Animation Indicators_Anim;

	[Header("Скрипты")]
	public IventScript IvntScript;

	IEnumerator IEnumerator_Text () 
	{
	    var originalString = Text_Notification.text;
	    Text_Notification.text = "";

	    var numCharsRevealed = 0;
	    while (numCharsRevealed < originalString.Length)
	    {
	        ++numCharsRevealed;
	        Text_Notification.text = originalString.Substring(0, numCharsRevealed);
	        if (Text_Notification.text == originalString){
	        	yield return new WaitForSeconds(2f);
		        if (IntText == 0){
		        Text_Notification.text = "";
		    	}
		    	else
		    	Notification_Military();
	    	}
	        yield return new WaitForSeconds(0.07f);
        }
    }

    IEnumerator IEnumerator_Long_Text () 
	{
	    var originalString = Text_Notification.text;
	    Text_Notification.text = "";

	    var numCharsRevealed = 0;
	    while (numCharsRevealed < originalString.Length)
	    {
	        ++numCharsRevealed;
	        Text_Notification.text = originalString.Substring(0, numCharsRevealed);
	        if (Text_Notification.text == originalString){
	        	yield return new WaitForSeconds(4f);
	        	Text_Anim.Play();

	        	yield return new WaitForSeconds(1f);
		        Text_Notification.text = "";

		        yield return new WaitForSeconds(4f);
		        Tutorial_Panel.SetActive(true);
		        Tutorial_Anim.Play("OnPanel");
		        EventFunction.enabled = false;

		        yield return new WaitForSeconds(2f);
		        EventFunction.enabled = true;
	    	}
	        yield return new WaitForSeconds(0.07f);
        }
    }

    public void Notification_Tutorial ()
    {
    	Text_Notification.text = "Много кликайте по экрану, чтобы бежать";
        StartCoroutine(IEnumerator_Long_Text());
    }

    public void Notification_Omon ()
    {
    	Text_Notification.text = "Вы смогли убежать!";
        StartCoroutine(IEnumerator_Text());
    }

    public void Notification_Military ()
    {
    	IntText += 1;

    	if (IntText == 6){
    	IvntScript.Open_Syringle_Panel();
    	EventFunction.enabled = true;
    	}

    	if (IntText == 5){
        Text_Notification.text = "А теперь немедлен.. ЧТО ТЫ ДЕЛАЕШЬ";
        StartCoroutine(IEnumerator_Text());
    	}

    	if (IntText == 4){
        Text_Notification.text = "Срочники расстреляют вас на месте";
        StartCoroutine(IEnumerator_Text());
    	}

    	if (IntText == 3){
        Text_Notification.text = "В случае неповиновения";
        StartCoroutine(IEnumerator_Text());
    	}

    	if (IntText == 2){
        Text_Notification.text = "Дальнейший проход запрещен";
        StartCoroutine(IEnumerator_Text());
    	}

    	if (IntText == 1){
    	Text_Notification.text = "Я генерал Михаил Залупян";
        StartCoroutine(IEnumerator_Text());
    	}
    }
}