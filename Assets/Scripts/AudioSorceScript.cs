using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSorceScript : MonoBehaviour 
{
	[Header("Классическая музыка")]
	public AudioSource MusicAudioSorce;

	[Header("Реверс музыка")]
	public AudioSource ReverseMusicAudioSorce;

	[Header("Смерть музыка")]
	public AudioSource DeadMusicAudioSorce;

	[Header("Концовка музыка")]
	public AudioSource EndMusicAudioSorce;

	// -- Классика
	public void Music_On()
	{
		StartCoroutine(MusicEnumeratorOn());
	}
    private IEnumerator MusicEnumeratorOn(){
        float speed = 0.02f;
        while(MusicAudioSorce.volume < 0.08){
            MusicAudioSorce.volume += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
	public void Music_Off()
	{
		StartCoroutine(MusicEnumeratorOff());
	}
	private IEnumerator MusicEnumeratorOff(){
        float speed = 0.02f;
        while(MusicAudioSorce.volume > 0){
            MusicAudioSorce.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Классика (скорость произвидения)
    public void Music_Pitch_On()
	{
		StartCoroutine(Music_Pitch_EnumeratorOn());
	}
    public IEnumerator Music_Pitch_EnumeratorOn()
    {
    	float speed = 0.02f;
    	while(MusicAudioSorce.pitch < 1.3){
    		MusicAudioSorce.pitch += speed;
    		yield return new WaitForSeconds(0.1f);
    	}
    }
    public void Music_Pitch_Off()
	{
		StartCoroutine(Music_Pitch_EnumeratorOff());
	}
    public IEnumerator Music_Pitch_EnumeratorOff()
    {
    	float speed = 0.02f;
    	while(MusicAudioSorce.pitch > 1){
    		MusicAudioSorce.pitch -= speed;
    		yield return new WaitForSeconds(0.1f);
    	}
    }

    // -- Реверс
	public void ReverseMusic_On()
	{
		StartCoroutine(ReverseMusicEnumeratorOn());
	}
    private IEnumerator ReverseMusicEnumeratorOn(){
        float speed = 0.02f;
        while(ReverseMusicAudioSorce.volume < 0.08){
            ReverseMusicAudioSorce.volume += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
	public void ReverseMusic_Off()
	{
		StartCoroutine(MusicEnumeratorOff());
	}
	private IEnumerator ReverseMusicEnumeratorOff(){
        float speed = 0.02f;
        while(ReverseMusicAudioSorce.volume > 0){
            ReverseMusicAudioSorce.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // -- Смерть
	public void DeadMusic_On()
	{
		StartCoroutine(DeadMusicEnumeratorOn());
	}
    private IEnumerator DeadMusicEnumeratorOn(){
        float speed = 0.02f;
        while(DeadMusicAudioSorce.volume < 0.5){
            DeadMusicAudioSorce.volume += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
	public void DeadMusic_Off()
	{
		StartCoroutine(DeadMusicEnumeratorOff());
	}
	private IEnumerator DeadMusicEnumeratorOff(){
        float speed = 0.02f;
        while(DeadMusicAudioSorce.volume > 0){
            DeadMusicAudioSorce.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // -- Концовка
	public void EndMusic_On()
	{
		StartCoroutine(EndMusicEnumeratorOn());
	}
    private IEnumerator EndMusicEnumeratorOn(){
        float speed = 0.02f;
        while(EndMusicAudioSorce.volume < 0.4){
            EndMusicAudioSorce.volume += speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
	public void EndMusic_Off()
	{
		StartCoroutine(EndMusicEnumeratorOff());
	}
	private IEnumerator EndMusicEnumeratorOff(){
        float speed = 0.02f;
        while(EndMusicAudioSorce.volume > 0){
            EndMusicAudioSorce.volume -= speed;
            yield return new WaitForSeconds(0.1f);
        }
    }
}