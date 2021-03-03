using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Audios { Injured,MouseClick,ButtonFeedBack,ButtonDown,SwitchFeedBack,GetGold,GetShield,Die,ShieldDestroy,GameOver,Prompt}

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager soundsManager;
    public AudioSource[] audioSources;

    /// <summary>
    /// Inicia lizar Singletone de soundsManager
    /// </summary>
    private void Awake()
    {
        if (soundsManager == null)
        {
            soundsManager = this;
        }           
        else
        {
            Destroy(gameObject);
        }          
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayAudio(Audios.MouseClick);
        }
    }

    public void PlayAudio(Audios audio)
    {
        switch (audio)
        {
            case Audios.Injured:
                audioSources[2].Play();
                break;
            case Audios.MouseClick:
                audioSources[6].Play();
                break;
            case Audios.ButtonDown:
                audioSources[1].Play();
                break;
            case Audios.ButtonFeedBack:
                audioSources[5].Play();
                break;
            case Audios.SwitchFeedBack:
                audioSources[3].Play();
                break;
            case Audios.GetGold:
                audioSources[0].Play();
                break;
            case Audios.GetShield:
                audioSources[4].Play();
                break;
            case Audios.ShieldDestroy:
                audioSources[9].Play();
                break;
            case Audios.Die:
                audioSources[8].Play();
                break;
            case Audios.GameOver:
                audioSources[7].Play();
                break;
            case Audios.Prompt:
                audioSources[10].Play();
                break;
        }
    }
}
