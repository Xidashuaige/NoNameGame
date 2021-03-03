using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.scoreManager.AddScore(other.GetComponent<Player>().playerID);
            SoundsManager.soundsManager.PlayAudio(Audios.GetGold);
            Destroy(gameObject);
        }       
    }
}
