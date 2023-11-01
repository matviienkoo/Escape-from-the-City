using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour 
{
	public GameObject Strange_Panel;
	public Animation Strange_Animation;
	public GameObject SoundStrange;

	public void Telegramm_Link ()
	{
		Application.OpenURL ("https://t.me/deedokk");
	}

	public void Telegramm_Button ()
	{
		Application.OpenURL ("https://t.me/deedokk");
		StartCoroutine(WaitTelegramm());
	}

	IEnumerator WaitTelegramm()
    {
		yield return new WaitForSeconds(1f);
		Strange_Panel.SetActive(true);
		SoundStrange.SetActive(true);
		Strange_Animation.Play();

		yield return new WaitForSeconds(6f);
		Strange_Panel.SetActive(false);
		SoundStrange.SetActive(false);
	}

	public void Rate_Button ()
	{
		Application.OpenURL ("https://play.google.com/store/apps/details?id=com.cybergnida.saratov");
	}

	public void Vk_Button ()
	{
		Application.OpenURL ("https://vk.com/binbxxxne");
	}
}