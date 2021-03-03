using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GoldSpawn gs;
    public Text[] scoreTexts;
    public static ScoreManager scoreManager;

    [HideInInspector]public int[] scores = new int[2];
    
    private void Awake()
    {
        if (scoreManager == null)
        {
            scoreManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Subir punto
    /// </summary>
    /// <param name="PlayerID"></param>
    public void AddScore(int PlayerID)
    {
        Invoke(nameof(DelayResetGold), 0.1f);
        scores[PlayerID]++;
        scoreTexts[PlayerID].text = "Score: " + scores[PlayerID];
    }

    /// <summary>
    /// Resetear monedas con retraso
    /// </summary>
    private void DelayResetGold()
    {
        gs.ResetGolds();
    } 
}
