using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchWords : MonoBehaviour
{
    public GameObject mySwitch;
    public Vector3 offset;
    public int playerID;

    void Update()
    {
        if (mySwitch.GetComponent<SwitchController>().canPush && mySwitch.GetComponent<SwitchController>().playersInRange[playerID])
        {
            // Mostrar aviso de boton
            GetComponent<Text>().enabled = true;
        }           
        else if (!mySwitch.GetComponent<SwitchController>().canPush)
        {
            // Ocultar aviso de boton
            GetComponent<Text>().enabled = false;
        }
            
        // Poner el texto al lado de boton
        transform.position = mySwitch.transform.position + offset;
    }
}
