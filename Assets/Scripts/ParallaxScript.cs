using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxScript : MonoBehaviour 
{
    private bool BoolPsyhodelic;
    private bool BoolAdsBonus;

    [Header("Игрок")]
    public Animator PlayerAnimator;
    public float clicksPerSecond;
    public float Speed;

    [Header("Настройка анимации игрока")]
    public Image PlayerImage;
    public Sprite PlayerSprite;

    [Header("Фон города")]
    [SerializeField] MeshRenderer MeshBackground;
    private Vector2 MeshBackground_Offset;

    [Header("Фон света")]
    [SerializeField] MeshRenderer MeshLight;
    private Vector2 MeshLight_Offset;

    private void Start ()
    {
        MeshBackground_Offset = MeshBackground.sharedMaterial.mainTextureOffset;
        MeshLight_Offset = MeshLight.sharedMaterial.mainTextureOffset;
    }

    public void PsyhodelicEffect ()
    {
        BoolPsyhodelic = true;
    }

    public void ClasicEffect ()
    {
        BoolPsyhodelic = false;
    }

    public void AdsBonus ()
    {
        BoolAdsBonus = true;
        StartCoroutine(EnableBonus());
    }

    IEnumerator EnableBonus()
    {
        yield return new WaitForSeconds(60);
        BoolAdsBonus = false;
    }

    private void FixedUpdate ()
    {
        clicksPerSecond = PlayerPrefs.GetFloat("clicksPerSecond");

        if (clicksPerSecond >= 2 && BoolAdsBonus == true)
        {
            Speed += 0.52f;
            PlayerAnimator.enabled = true;
        }

        if (clicksPerSecond >= 2 && BoolPsyhodelic == false)
        {
            Speed += 0.42f;
            PlayerAnimator.enabled = true;
        }

        if (clicksPerSecond >= 2 && BoolPsyhodelic == true)
        {
            Speed -= 0.42f;
            PlayerAnimator.enabled = true;
        }

        if (clicksPerSecond == 0)
        {
            PlayerImage.sprite = PlayerSprite;
            PlayerAnimator.enabled = false;
        }

        var x = Mathf.Repeat(Time.fixedDeltaTime * Speed, 1);
        var offset = new Vector2(x, MeshBackground_Offset.y);
        MeshBackground.sharedMaterial.mainTextureOffset = offset;

        var y = Mathf.Repeat(Time.fixedDeltaTime * Speed, 1);
        var offfset = new Vector2(x, MeshLight_Offset.y);
        MeshLight.sharedMaterial.mainTextureOffset = offfset;
    }
}