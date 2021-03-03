using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public int counrDownTime = 100;
    private Text countText;

    private void Start()
    {
        countText = GetComponent<Text>();
        InvokeRepeating(nameof(RestTime), 1, 1);
    }

    private void RestTime()
    {
        if (!GameManager.gameManager.gameOver)
        {
            counrDownTime--;
            countText.text = counrDownTime.ToString();

            if (counrDownTime <= 0)
            {
                GameManager.gameManager.GameOver();
                CancelInvoke();
            }
        }     
    }
}
