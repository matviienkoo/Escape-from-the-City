using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarketScript : MonoBehaviour 
{
	private float Current_Life;
    private float Current_Food;
    private float Current_Water;

	[Header("Деньги")]
	public float Money;

    [Header("Обьекты Покупок")]
    public float Price_Trash;
    public Button Button_Trash;

    public float Price_Puddle;
    public Button Button_Puddle;

    public float Price_Askorbinka;
    public Button Button_Askorbinka;

    public float Price_Snikers;
    public Button Button_Snikers;

    public float Price_Water;
    public Button Button_Water;

    public float Price_Bandage;
    public Button Button_Bandage;

    public float Price_Doshik;
    public Button Button_Doshik;

    public float Price_Nesquik;
    public Button Button_Nesquik;

    public float Price_GrandFatherVodka;
    public Button Button_GrandFatherVodka;

    public float Price_Salo;
    public Button Button_Salo;

    public float Price_Vodka;
    public Button Button_Vodka;

    public float Price_Antiseptic;
    public Button Button_Antiseptic;

    public float Price_Shashlik;
    public Button Button_Shashlik;

    public float Price_Duches;
    public Button Button_Duches;

    public float Price_Pharmacy;
    public Button Button_Pharmacy;

    public float Price_Caviar;
    public Button Button_Caviar;

    public float Price_Champange;
    public Button Button_Champange;

    public float Price_Hospital;
    public Button Button_Hospital;

    float lerpSpeed;

	public void TrashButton ()
	{
		if (Money >= Price_Trash)
		{
			Money -= Price_Trash;

			Current_Food += 6;
			Current_Water -= 3;
			Current_Life -= 1;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void PuddleButton ()
	{
		if (Money >= Price_Puddle)
		{
			Money -= Price_Puddle;

			Current_Water += 6;
			Current_Food -= 3;
			Current_Life -= 1;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void AskorbinkaButton ()
	{
		if (Money >= Price_Askorbinka)
		{
			Money -= Price_Askorbinka;

			Current_Life += 10;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void SnikersButton ()
	{
		if (Money >= Price_Snikers)
		{
			Money -= Price_Snikers;

			Current_Food += 8;
			Current_Water -= 2;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void WaterButton ()
	{
		if (Money >= Price_Water)
		{
			Money -= Price_Water;

			Current_Water += 8;
			Current_Life += 2;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void BandageButton ()
	{
		if (Money >= Price_Bandage)
		{
			Money -= Price_Bandage;

			Current_Life += 15;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void DoshikButton ()
	{
		if (Money >= Price_Doshik)
		{
			Money -= Price_Doshik;

			Current_Food += 15;
			Current_Water += 3;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void NesquikButton ()
	{
		if (Money >= Price_Nesquik)
		{
			Money -= Price_Nesquik;

			Current_Water += 15;
			Current_Food += 3;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void GrandFatherVodkaButton ()
	{
		if (Money >= Price_GrandFatherVodka)
		{
			Money -= Price_GrandFatherVodka;

			Current_Life += 20;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void SaloButton ()
	{
		if (Money >= Price_Salo)
		{
			Money -= Price_Salo;

			Current_Food += 30;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void VodkaButton ()
	{
		if (Money >= Price_Vodka)
		{
			Money -= Price_Vodka;

			Current_Water += 30;
			Current_Life += 8;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void AntisepticButton ()
	{
		if (Money >= Price_Antiseptic)
		{
			Money -= Price_Antiseptic;

			Current_Life += 30;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void ShashlikButton ()
	{
		if (Money >= Price_Shashlik)
		{
			Money -= Price_Shashlik;
	
			Current_Food += 65;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void DuchesButton ()
	{
		if (Money >= Price_Duches)
		{
			Money -= Price_Duches;

			Current_Water += 65;

			PlayerPrefs.SetFloat("Money",Money);
	   		PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void PharmacyButton ()
	{
		if (Money >= Price_Pharmacy)
		{
			Money -= Price_Pharmacy;

			Current_Life += 50;
			Current_Food += 50;
			Current_Water += 50;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void CaviarButton ()
	{
		if (Money >= Price_Caviar)
		{
			Money -= Price_Caviar;

			Current_Food += 100;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void ChampangeButton ()
	{
		if (Money >= Price_Champange)
		{
			Money -= Price_Champange;

			Current_Water += 100;

			PlayerPrefs.SetFloat("Money",Money);
	   		PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	public void HospitalButton ()
	{
		if (Money >= Price_Hospital)
		{
			Money -= Price_Hospital;

			Current_Water += 100;
			Current_Food += 100;
			Current_Life += 100;

			PlayerPrefs.SetFloat("Money",Money);
			PlayerPrefs.SetFloat("Current_Life", Current_Life);
			PlayerPrefs.SetFloat("Current_Food", Current_Food);
	   		PlayerPrefs.SetFloat("Current_Water", Current_Water);
		}
	}

	private void Update ()
	{
		Current_Life = PlayerPrefs.GetFloat("Current_Life");
		Current_Food = PlayerPrefs.GetFloat("Current_Food");
		Current_Water = PlayerPrefs.GetFloat("Current_Water");

		Money = PlayerPrefs.GetFloat("Money");

		// Определение возможности покупки ПОМОЙКИ
		if (Money >= Price_Trash){
		Button_Trash.interactable = true;
		}
		else
		Button_Trash.interactable = false;

		// Определение возможности покупки КАНАВЫ
		if (Money >= Price_Puddle){
		Button_Puddle.interactable = true;
		}
		else
		Button_Puddle.interactable = false;

		// Определение возможности покупки АСКОРБИНКИ
		if (Money >= Price_Askorbinka){
		Button_Askorbinka.interactable = true;
		}
		else
		Button_Askorbinka.interactable = false;

		// Определение возможности покупки СНИКЕРСА
		if (Money >= Price_Snikers){
		Button_Snikers.interactable = true;
		}
		else
		Button_Snikers.interactable = false;

		// Определение возможности покупки ВОДЫ
		if (Money >= Price_Water){
		Button_Water.interactable = true;
		}
		else
		Button_Water.interactable = false;

		// Определение возможности покупки БИНТА
		if (Money >= Price_Bandage){
		Button_Bandage.interactable = true;
		}
		else
		Button_Bandage.interactable = false;

		// Определение возможности покупки ДОШИК
		if (Money >= Price_Doshik){
		Button_Doshik.interactable = true;
		}
		else
		Button_Doshik.interactable = false;

		// Определение возможности покупки НЕСКВИКА
		if (Money >= Price_Nesquik){
		Button_Nesquik.interactable = true;
		}
		else
		Button_Nesquik.interactable = false;

		// Определение возможности покупки ДЕДОВОЙ НАСТОЙКИ
		if (Money >= Price_GrandFatherVodka){
		Button_GrandFatherVodka.interactable = true;
		}
		else
		Button_GrandFatherVodka.interactable = false;

		// Определение возможности покупки САЛА
		if (Money >= Price_Salo){
		Button_Salo.interactable = true;
		}
		else
		Button_Salo.interactable = false;

		// Определение возможности покупки ВОДКИ
		if (Money >= Price_Vodka){
		Button_Vodka.interactable = true;
		}
		else
		Button_Vodka.interactable = false;

		// Определение возможности покупки АНТИСЕПТИКА
		if (Money >= Price_Antiseptic){
		Button_Antiseptic.interactable = true;
		}
		else
		Button_Antiseptic.interactable = false;

		// Определение возможности покупки ШАШЛИКА
		if (Money >= Price_Shashlik){
		Button_Shashlik.interactable = true;
		}
		else
		Button_Shashlik.interactable = false;

		// Определение возможности покупки ДЮШЕСА
		if (Money >= Price_Duches){
		Button_Duches.interactable = true;
		}
		else
		Button_Duches.interactable = false;

		// Определение возможности покупки АПТЕЧКИ
		if (Money >= Price_Pharmacy){
		Button_Pharmacy.interactable = true;
		}
		else
		Button_Pharmacy.interactable = false;

		// Определение возможности покупки ИКРИ
		if (Money >= Price_Caviar){
		Button_Caviar.interactable = true;
		}
		else
		Button_Caviar.interactable = false;

		// Определение возможности покупки ШАМПАНСКОГО
		if (Money >= Price_Champange){
		Button_Champange.interactable = true;
		}
		else
		Button_Champange.interactable = false;

		// Определение возможности покупки ПЛАТНОЙ МЕДИЦИНЫ
		if (Money >= Price_Hospital){
		Button_Hospital.interactable = true;
		}
		else
		Button_Hospital.interactable = false;
	}
}