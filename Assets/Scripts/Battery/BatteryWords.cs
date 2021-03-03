using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryWords : MonoBehaviour
{
    public Transform myBattery;
    public Vector3 offset;
    public BatteryController batteryController;
    public int PlayerID;

    void Update()
    {
        // Poner el texto al lado de bateria
        transform.position = myBattery.transform.position + offset;

        // Mostrar el texto
        if (batteryController.playersInRange[PlayerID])
            GetComponent<Text>().enabled = true;

        // Ocultar el texto
        else
            GetComponent<Text>().enabled = false;
    }
}
