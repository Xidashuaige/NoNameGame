using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    /// <summary>
    /// Abrir escudo
    /// </summary>
    public void OpenShield()
    {
        if (!transform.Find("Shield").gameObject.activeInHierarchy)
        {
            transform.Find("Shield").gameObject.SetActive(true);
            SoundsManager.soundsManager.PlayAudio(Audios.GetShield);
        }       
    }

    /// <summary>
    /// Cerrar escudo
    /// </summary>
    public void CloseShield()
    {
        if (transform.Find("Shield").gameObject.activeInHierarchy)
        {
            transform.Find("Shield").gameObject.SetActive(false);
            SoundsManager.soundsManager.PlayAudio(Audios.ShieldDestroy);
        }        
    }
}
