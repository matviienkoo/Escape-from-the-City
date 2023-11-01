using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeScript : MonoBehaviour 
{
	private float lerpSpeed;

	[Header("Деньги")]
	public float Money;
	public float RewardForDistance;

	[Header("Майкрафт сервер")]
    public Image MinecraftServerBar;
    public float Current_MinecraftServer, Max_MinecraftServer = 100;

    public TextMeshProUGUI Text_Price_MinecraftServer;
	public float Price_MinecraftServer;

	public GameObject Second_MinecraftServer_Upgrade;
	public GameObject Thirt_MinecraftServer_Upgrade;

	public GameObject Locker_MinecraftServer;
	public GameObject AllBuy_MinecraftServer;

	[Header("Сайт")]
    public Image SiteBar;
    public float Current_Site, Max_Site = 100;

    public TextMeshProUGUI Text_Price_Site;
	public float Price_Site;

	public GameObject Second_Site_Upgrade;
	public GameObject Thirt_Site_Upgrade;

	public GameObject Locker_Site;
	public GameObject AllBuy_Site;

	[Header("Казино")]
	public Image CasinoBar;
    public float Current_Casino, Max_Casino = 100;

    public TextMeshProUGUI Text_Price_Casino;
	public float Price_Casino;

	public GameObject Second_Casino_Upgrade;
	public GameObject Thirt_Casino_Upgrade;

	public GameObject Locker_Casino;
	public GameObject AllBuy_Casino;

	[Header("Криптовалюта")]
	public Image CryptoBar;
    public float Current_Crypto, Max_Crypto = 100;

    public TextMeshProUGUI Text_Price_Crypto;
	public float Price_Crypto;

	public GameObject Second_Crypto_Upgrade;
	public GameObject Thirt_Crypto_Upgrade;

	public GameObject Locker_Crypto;
	public GameObject AllBuy_Crtpto;

	[Header("Скам")]
	public Image ScamBar;
    public float Current_Scam, Max_Scam = 100;

    public TextMeshProUGUI Text_Price_Scam;
	public float Price_Scam;

	public GameObject Second_Scam_Upgrade;
	public GameObject Thirt_Scam_Upgrade;

	public GameObject Locker_Scam;
	public GameObject AllBuy_Scam;

	private void Start ()
	{
		// Настраивает кнопку апгрейда (Майкрафт Сервера)
		Current_MinecraftServer = PlayerPrefs.GetFloat("Current_MinecraftServer");
		Max_MinecraftServer = 100;

		if (Current_MinecraftServer == 0f)
		{
			Price_MinecraftServer = 15;
			PlayerPrefs.SetFloat ("Price_MinecraftServer", Price_MinecraftServer);
		}

		if (Current_MinecraftServer >= 50f)
		{
			Second_MinecraftServer_Upgrade.SetActive(true);
		}

		if (Current_MinecraftServer == 100f)
		{
			Thirt_MinecraftServer_Upgrade.SetActive(true);
		}

		// Настраивает кнопку апгрейда (Сайт)
		Current_Site = PlayerPrefs.GetFloat("Current_Site");
		Max_Site = 100;

		if (Current_Site == 0f)
		{
			Price_Site = 600;
			PlayerPrefs.SetFloat ("Price_Site", Price_Site);
		}

		if (Current_Site >= 50f)
		{
			Second_Site_Upgrade.SetActive(true);
		}

		if (Current_Site == 100f)
		{
			Thirt_Site_Upgrade.SetActive(true);
		}

		// Настраивает кнопку апгрейда (Казино)
		Current_Casino = PlayerPrefs.GetFloat("Current_Casino");
		Max_Casino = 100;

		if (Current_Casino == 0f)
		{
			Price_Casino = 2500;
			PlayerPrefs.SetFloat ("Price_Casino", Price_Casino);
		}

		if (Current_Casino >= 50f)
		{
			Second_Casino_Upgrade.SetActive(true);
		}

		if (Current_Casino == 100f)
		{
			Thirt_Casino_Upgrade.SetActive(true);
		}

		// Настраивает кнопку апгрейда (Криптовалюта)
		Current_Crypto = PlayerPrefs.GetFloat("Current_Crypto");
		Max_Crypto = 100;

		if (Current_Crypto == 0f)
		{
			Price_Crypto = 23000;
			PlayerPrefs.SetFloat ("Price_Crypto", Price_Crypto);
		}

		if (Current_Crypto >= 50f)
		{
			Second_Crypto_Upgrade.SetActive(true);
		}

		if (Current_Crypto == 100f)
		{
			Thirt_Crypto_Upgrade.SetActive(true);
		}

		// Настраивает кнопку апгрейда (Скам)
		Current_Scam = PlayerPrefs.GetFloat("Current_Scam");
		Max_Scam = 100;

		if (Current_Scam == 0f)
		{
			Price_Scam = 500000;
			PlayerPrefs.SetFloat ("Price_Scam", Price_Scam);
		}

		if (Current_Scam >= 50f)
		{
			Second_Scam_Upgrade.SetActive(true);
		}

		if (Current_Scam == 100f)
		{
			Thirt_Scam_Upgrade.SetActive(true);
		}
	}

	public void MinecraftServerButton ()
	{	
		if (Current_MinecraftServer < 100){
		if (Money >= Price_MinecraftServer)
		{
			Money -= Price_MinecraftServer;
			Current_MinecraftServer += 12.5f;

			if (Current_MinecraftServer == 12.5f)
			{
				RewardForDistance += 1;
				Price_MinecraftServer = 30;
			}

			if (Current_MinecraftServer == 25f)
			{
				RewardForDistance += 2;
				Price_MinecraftServer = 85;
			}

			if (Current_MinecraftServer == 37.5f)
			{
				RewardForDistance += 4;
				Price_MinecraftServer = 200;
			}

			if (Current_MinecraftServer == 50f)
			{
				RewardForDistance += 5;
				Price_MinecraftServer = 250;
			}

			if (Current_MinecraftServer == 62.5f)
			{
				RewardForDistance += 8;
				Price_MinecraftServer = 350;

				// включает второй обьект прокачки
				Second_MinecraftServer_Upgrade.SetActive(true);
			}

			if (Current_MinecraftServer == 75f)
			{
				RewardForDistance += 10;
				Price_MinecraftServer = 450;

			}

			if (Current_MinecraftServer == 87.5f)
			{
				RewardForDistance += 15;
				Price_MinecraftServer = 650;
			}

			if (Current_MinecraftServer == 100f)
			{
				RewardForDistance += 20;

				// включает трейтий обьект прокачки
				Thirt_MinecraftServer_Upgrade.SetActive(true);
			}

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat ("RewardForDistance", RewardForDistance);
			PlayerPrefs.SetFloat ("Price_MinecraftServer", Price_MinecraftServer);
			PlayerPrefs.SetFloat ("Current_MinecraftServer", Current_MinecraftServer);
		}
		}
	}

	public void SiteButton ()
	{	
		if (Current_Site < 100){
		if (Money >= Price_Site)
		{
			Money -= Price_Site;
			Current_Site += 12.5f;

			if (Current_Site == 12.5f)
			{
				RewardForDistance += 8;
				Price_Site = 800;
			}

			if (Current_Site == 25f)
			{
				RewardForDistance += 10;
				Price_Site = 1200;
			}

			if (Current_Site == 37.5f)
			{
				RewardForDistance += 12;
				Price_Site = 1600;
			}

			if (Current_Site == 50f)
			{
				RewardForDistance += 14;
				Price_Site = 2500;
			}

			if (Current_Site == 62.5f)
			{
				RewardForDistance += 16;
				Price_Site = 3500;

				// включает второй обьект прокачки
				Second_Site_Upgrade.SetActive(true);
			}

			if (Current_Site == 75f)
			{
				RewardForDistance += 20;
				Price_Site = 4500;
			}

			if (Current_Site == 87.5f)
			{
				RewardForDistance += 22;
				Price_Site = 5500;
			}

			if (Current_Site == 100f)
			{
				RewardForDistance += 25;

				// включает трейтий обьект прокачки
				Thirt_Site_Upgrade.SetActive(true);
			}

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat ("RewardForDistance", RewardForDistance);
			PlayerPrefs.SetFloat ("Price_Site", Price_Site);
			PlayerPrefs.SetFloat ("Current_Site", Current_Site);
		}
		}
	}

	public void CasinoButton ()
	{	
		if (Current_Casino < 100){
		if (Money >= Price_Casino)
		{
			Money -= Price_Casino;
			Current_Casino += 12.5f;

			if (Current_Casino == 12.5f)
			{
				RewardForDistance += 10;
				Price_Casino = 4000;
			}

			if (Current_Casino == 25f)
			{
				RewardForDistance += 15;
				Price_Casino = 6000;
			}

			if (Current_Casino == 37.5f)
			{
				RewardForDistance += 20;
				Price_Casino = 12000;
			}

			if (Current_Casino == 50f)
			{
				RewardForDistance += 28;
				Price_Casino = 18000;
			}

			if (Current_Casino == 62.5f)
			{
				RewardForDistance += 35;
				Price_Casino = 23500;

				// включает второй обьект прокачки
				Second_Casino_Upgrade.SetActive(true);
			}

			if (Current_Casino == 75f)
			{
				RewardForDistance += 45;
				Price_Casino = 29500;
			}

			if (Current_Casino == 87.5f)
			{
				RewardForDistance += 50;
				Price_Casino = 35000;
			}

			if (Current_Casino == 100f)
			{
				RewardForDistance += 65;

				// включает трейтий обьект прокачки
				Thirt_Casino_Upgrade.SetActive(true);
			}

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat ("RewardForDistance", RewardForDistance);
			PlayerPrefs.SetFloat ("Price_Casino", Price_Casino);
			PlayerPrefs.SetFloat ("Current_Casino", Current_Casino);
		}
		}
	}

	public void CryptoButton ()
	{	
		if (Current_Crypto < 100){
		if (Money >= Price_Crypto)
		{
			Money -= Price_Crypto;
			Current_Crypto += 12.5f;

			if (Current_Crypto == 12.5f)
			{
				RewardForDistance += 50;
				Price_Crypto = 35000;
			}

			if (Current_Crypto == 25f)
			{
				RewardForDistance += 85;
				Price_Crypto = 75000;
			}

			if (Current_Crypto == 37.5f)
			{
				RewardForDistance += 150;
				Price_Crypto = 225000;
			}

			if (Current_Crypto == 50f)
			{
				RewardForDistance += 300;
				Price_Crypto = 300000;
			}

			if (Current_Crypto == 62.5f)
			{
				RewardForDistance += 1000;
				Price_Crypto = 450000;

				// включает второй обьект прокачки
				Second_Crypto_Upgrade.SetActive(true);
			}

			if (Current_Crypto == 75f)
			{
				RewardForDistance += 1200;
				Price_Crypto = 650000;
			}

			if (Current_Crypto == 87.5f)
			{
				RewardForDistance += 1500;
				Price_Crypto = 850000;
			}

			if (Current_Crypto == 100f)
			{
				RewardForDistance += 3000;

				// включает трейтий обьект прокачки
				Thirt_Crypto_Upgrade.SetActive(true);
			}

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat ("RewardForDistance", RewardForDistance);
			PlayerPrefs.SetFloat ("Price_Crypto", Price_Crypto);
			PlayerPrefs.SetFloat ("Current_Crypto", Current_Crypto);
		}
		}
	}

	public void ScamButton ()
	{	
		if (Current_Scam < 100){
		if (Money >= Price_Scam)
		{
			Money -= Price_Scam;
			Current_Scam += 12.5f;

			if (Current_Scam == 12.5f)
			{
				RewardForDistance += 500;
				Price_Scam = 1000000;
			}

			if (Current_Scam == 25f)
			{
				RewardForDistance += 1250;
				Price_Scam = 5000000;
			}

			if (Current_Scam == 37.5f)
			{
				RewardForDistance += 3500;
				Price_Scam = 10000000;
			}

			if (Current_Scam == 50f)
			{
				RewardForDistance += 5000;
				Price_Scam = 30000000;
			}

			if (Current_Scam == 62.5f)
			{
				RewardForDistance += 10000;
				Price_Scam = 50000000;

				// включает второй обьект прокачки
				Second_Scam_Upgrade.SetActive(true);
			}

			if (Current_Scam == 75f)
			{
				RewardForDistance += 20000;
				Price_Scam = 100000000;
			}

			if (Current_Scam == 87.5f)
			{
				RewardForDistance += 30000;
				Price_Scam = 250000000;
			}

			if (Current_Scam == 100f)
			{
				RewardForDistance += 50000;

				// включает трейтий обьект прокачки
				Thirt_Scam_Upgrade.SetActive(true);
			}

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat ("RewardForDistance", RewardForDistance);
			PlayerPrefs.SetFloat ("Price_Scam", Price_Scam);
			PlayerPrefs.SetFloat ("Current_Scam", Current_Scam);
		}
		}
	}

	private void Update ()
	{
		RewardForDistance = PlayerPrefs.GetFloat("RewardForDistance");
		Money = PlayerPrefs.GetFloat("Money");
		lerpSpeed = 2f * Time.deltaTime;

		// -- (МАЙКРАФТ СЕРВЕР)
		Current_MinecraftServer = PlayerPrefs.GetFloat("Current_MinecraftServer");
		Price_MinecraftServer = PlayerPrefs.GetFloat("Price_MinecraftServer");
		Text_Price_MinecraftServer.text = Price_MinecraftServer.ToString ("n0");

		MinecraftServerBar.fillAmount = Mathf.Lerp(MinecraftServerBar.fillAmount, (Current_MinecraftServer / Max_MinecraftServer), lerpSpeed);

		if (Current_MinecraftServer < 100)
		{
			AllBuy_MinecraftServer.SetActive(false);
			if (Money >= Price_MinecraftServer){
			Locker_MinecraftServer.SetActive(false);
			}
			else
			Locker_MinecraftServer.SetActive(true);
		}
		
		if (Current_MinecraftServer >= 100)
		{
			AllBuy_MinecraftServer.SetActive(true);
			Locker_MinecraftServer.SetActive(true);
		}

		// -- (САЙТ)
		Current_Site = PlayerPrefs.GetFloat("Current_Site");
		Price_Site = PlayerPrefs.GetFloat("Price_Site");
		Text_Price_Site.text = Price_Site.ToString ("n0");

		SiteBar.fillAmount = Mathf.Lerp(SiteBar.fillAmount, (Current_Site / Max_Site), lerpSpeed);

		if (Current_Site < 100)
		{
			AllBuy_Site.SetActive(false);
			if (Money >= Price_Site){
			Locker_Site.SetActive(false);
			}
			else
			Locker_Site.SetActive(true);
		}

		if (Current_Site >= 100)
		{
			AllBuy_Site.SetActive(true);
			Locker_Site.SetActive(true);
		}

		// -- (КАЗИНО)
		Current_Casino = PlayerPrefs.GetFloat("Current_Casino");
		Price_Casino = PlayerPrefs.GetFloat("Price_Casino");
		Text_Price_Casino.text = Price_Casino.ToString ("n0");

		CasinoBar.fillAmount = Mathf.Lerp(CasinoBar.fillAmount, (Current_Casino / Max_Casino), lerpSpeed);

		if (Current_Casino < 100)
		{
			AllBuy_Casino.SetActive(false);
			if (Money >= Price_Casino){
			Locker_Casino.SetActive(false);
			}
			else
			Locker_Casino.SetActive(true);
		}

		if (Current_Casino >= 100)
		{
			AllBuy_Casino.SetActive(true);
			Locker_Casino.SetActive(true);
		}

		// -- (КРИПТОВАЛЮТА)
		Current_Crypto = PlayerPrefs.GetFloat("Current_Crypto");
		Price_Crypto = PlayerPrefs.GetFloat("Price_Crypto");
		Text_Price_Crypto.text = Price_Crypto.ToString ("n0");

		CryptoBar.fillAmount = Mathf.Lerp(CryptoBar.fillAmount, (Current_Crypto / Max_Crypto), lerpSpeed);

		if (Current_Crypto < 100)
		{
			AllBuy_Crtpto.SetActive(false);
			if (Money >= Price_Crypto){
			Locker_Crypto.SetActive(false);
			}
			else
			Locker_Crypto.SetActive(true);
		}
		
		if (Current_Crypto >= 100)
		{
			AllBuy_Crtpto.SetActive(true);
			Locker_Crypto.SetActive(true);
		}

		// -- (СКАМ)
		Current_Scam = PlayerPrefs.GetFloat("Current_Scam");
		Price_Scam = PlayerPrefs.GetFloat("Price_Scam");
		Text_Price_Scam.text = Price_Scam.ToString ("n0");

		ScamBar.fillAmount = Mathf.Lerp(ScamBar.fillAmount, (Current_Scam / Max_Scam), lerpSpeed);

		if (Current_Scam < 100)
		{
			AllBuy_Scam.SetActive(false);
			if (Money >= Price_Scam){
			Locker_Scam.SetActive(false);
			}
			else
			Locker_Scam.SetActive(true);
		}

		if (Current_Scam >= 100)
		{
			AllBuy_Scam.SetActive(true);
			Locker_Scam.SetActive(true);
		}
	}
}