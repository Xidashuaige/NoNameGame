using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSlider : MonoBehaviour
{
    public GameObject[] mySwitchs;
    public Image[] switchSprites;
    public Vector3 offset;
    [HideInInspector]public Slider switchSlider;

    private bool count = false;
    
    private int switchNum;

    private void Start()
    {
        switchSlider = GetComponent<Slider>();
        for (int i = 0; i < switchSprites.Length; i++)
        {
            switchSprites[i].color = new Color(switchSprites[i].color.r, switchSprites[i].color.g, switchSprites[i].color.b, 0);
        }
    }

    void Update()
    {
        if (count)
        {
            switchSlider.value -= Time.deltaTime;          
        }
        transform.position = mySwitchs[switchNum].transform.position + offset;
    }

    /// <summary>
    /// Empezar a restar valor de slider
    /// </summary>
    /// <param name="switchNum"></param>
    public void StartCount(int switchNum)
    {
        this.switchNum = switchNum;
        count = true;
        switchSlider.value = 5;
        for (int i = 0; i < switchSprites.Length; i++)
        {
            switchSprites[i].color = new Color(switchSprites[i].color.r, switchSprites[i].color.g, switchSprites[i].color.b, 255);
        }
    }

    /// <summary>
    /// Ocultar slider
    /// </summary>
    public void CloseCount()
    {
        if(switchSlider.value <= 0)
        {
            count = false;
            for (int i = 0; i < switchSprites.Length; i++)
            {
                switchSprites[i].color = new Color(switchSprites[i].color.r, switchSprites[i].color.g, switchSprites[i].color.b, 0);
            }
        }        
    }
}
