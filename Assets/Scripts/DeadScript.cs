using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DeadScript : MonoBehaviour 
{
	public List<GameObject> ListGameObjects;
	public Image CheckMarkF;
	public Image CheckMarkS;

	public GameObject Ressurect_AudioSorce;
    public GameObject Police_Object;

	[Header("Переходная панель")]
	public GameObject Transtion_Panel;
    public Animation Transtion_Animation;

    [Header("Панель реанимации")]
    public GameObject Reanimation_Panel;
    public Animation Reanimation_Animation;
    public GameObject Reanimation_AudioSorce;

    [Header("Панель рекламной системы")]
    public GameObject Attemp_Panel;
    private int Attemp_Int;

    [Header("Панель смерти")]
    public GameObject Dead_Script;
    public GameObject Dead_Panel;
    public Animation Dead_Animation;
    public GameObject Dead_AudioSorce;
    public GameObject Paradise_Panel;
    public GameObject Start_Panel;
    public TextMeshProUGUI Paradise_Text;

    [Header("Системаная настройка")]
    public AmbulanceMoveScript AmbulanceScript; 
    public SettingNumbersScript SettingScript;
    public AudioSorceScript AudioScript;
    public TranstionScript TranstionFunction;
    public EventSystem EventFunction;
    public OmonMoveScript OmonScript;
    public SettingNumbersScript SettNumberScript;

    private void Start ()
    {
        StartCoroutine(IEnumeratorAttemps());
    }

    private void Update ()
    {
        Attemp_Int = PlayerPrefs.GetInt("Attemp_Int");
    }

    IEnumerator Text_System () 
    {
        var originalString = Paradise_Text.text;
        Paradise_Text.text = "";

        var numCharsRevealed = 0;
        while (numCharsRevealed < originalString.Length)
        {
            ++numCharsRevealed;
            Paradise_Text.text = originalString.Substring(0, numCharsRevealed);
            yield return new WaitForSeconds(0.07f);
        }
    }

    // ---- Реанимация ---- 
    public void Reanimation_Button ()
    {
    	Reanimation_Animation.Play();
    	EventFunction.enabled = false;
 		StartCoroutine(WaitRessurect());

        Attemp_Int += 1;
        PlayerPrefs.SetInt("Attemp_Int",Attemp_Int);
        if (Attemp_Int >= 3){
            StartCoroutine(IEnumeratorAttemps());
        }
    }

    IEnumerator IEnumeratorAttemps()
    {
        yield return new WaitForSeconds(3f);
        Attemp_Int = PlayerPrefs.GetInt("Attemp_Int");
        if (Attemp_Int >= 3)
        {
            Attemp_Panel.SetActive(true);
        }
    }

    IEnumerator WaitRessurect()
    {
    	// Музыка
    	Reanimation_AudioSorce.SetActive(false);
    	Ressurect_AudioSorce.SetActive(true);

    	yield return new WaitForSeconds(2f);
    	Transtion_Panel.SetActive(true);
    	Transtion_Animation.Play("Resurrect");
        OmonScript.DisableOmon();

    	yield return new WaitForSeconds(2f);
    	SettingScript.ChangeIndicatorsSlider();
    	Reanimation_Panel.SetActive(false);
    	CheckMarkF.fillAmount = 0;
    	CheckMarkS.fillAmount = 0;

    	yield return new WaitForSeconds(2f);
    	Ressurect_AudioSorce.SetActive(false);
    	Transtion_Panel.SetActive(false);
    	Dead_Script.SetActive(false);
    	EventFunction.enabled = true;
        AudioScript.Music_On();

        if (Police_Object.activeSelf == false){
    	AmbulanceScript.LaunchAmbulanceS_Target();
        }
    }

    // ---- Смерть ---- 
    public void Dead_Button ()
    {
    	Dead_Animation.Play();
    	EventFunction.enabled = false;
    	StartCoroutine(WaitDead());
    }

    IEnumerator WaitDead()
    {
    	// Музыка
    	Reanimation_AudioSorce.SetActive(false);
    	Dead_AudioSorce.SetActive(true);
        AudioScript.DeadMusic_On();

    	yield return new WaitForSeconds(2f);
    	Transtion_Panel.SetActive(true);
    	Transtion_Animation.Play("Resurrect");

    	yield return new WaitForSeconds(2f);
    	Dead_Panel.SetActive(true);

    	yield return new WaitForSeconds(2f);
    	Transtion_Panel.SetActive(false);
    	EventFunction.enabled = true;
    }

    // ---- Рай ----
    public void Paradise_Button ()
    {
        StartCoroutine(WaitParadise());
        Paradise_Panel.SetActive(true);
    }

    IEnumerator WaitParadise ()
    {
        yield return new WaitForSeconds(2f);
        Paradise_Text.text = "Имеет ли кто-нибудь второй шанс?..";
        StartCoroutine(Text_System());
        Start_Panel.SetActive(true);
        Dead_Panel.SetActive(false);
        PlayerPrefs.DeleteAll();

        int Int_Tutorial = 1;
        PlayerPrefs.SetInt("Int_Tutorial", Int_Tutorial);
        SettNumberScript.ChangeIndicatorsSlider();

        yield return new WaitForSeconds(4f);
        AudioScript.DeadMusic_Off();

        yield return new WaitForSeconds(3f);
        Paradise_Panel.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }

    // ---- Запуск основной кат-сцены ---- 
    private void OnEnable()
    {
    	// Отключить панели если они включены
        if (ListGameObjects[0].activeSelf || ListGameObjects[1].activeSelf || ListGameObjects[2].activeSelf)
        {
        	TranstionFunction.AllClosed();
    	}

    	// Запуск скорой помощи
        if (Police_Object.activeSelf == false){
    	AmbulanceScript.LaunchAmbulanceF_Target();
        }

    	EventFunction.enabled = false;
    	AudioScript.Music_Off();

    	// Переход на сцену реанимации
    	StartCoroutine(WaitReanimation());
    }   

    IEnumerator WaitReanimation()
    {
    	// Музыка
    	Reanimation_AudioSorce.SetActive(true);

        if (Police_Object.activeSelf == false){
    	yield return new WaitForSeconds(5f);
    	Transtion_Panel.SetActive(true);
    	Transtion_Animation.Play("Resurrect");
        }
        else
        yield return new WaitForSeconds(2f);
        Transtion_Panel.SetActive(true);
        Transtion_Animation.Play("Resurrect");

    	yield return new WaitForSeconds(2f);
    	Reanimation_Panel.SetActive(true);

    	yield return new WaitForSeconds(2f);
    	Transtion_Panel.SetActive(false);
    	EventFunction.enabled = true;
    }
}