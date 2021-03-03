using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaillingWords : MonoBehaviour
{
    public Transform myRailing;
    public Vector3 offset;
    public RailingController railingController;
    public int PlayerID;

    // Update is called once per frame
    void Update()
    {
        if (railingController != null)
        {
            // Poner el texto al lado de bateria
            transform.position = myRailing.transform.position + offset;

            // Mostrar el texto
            if (railingController.playersInRange[PlayerID])
                GetComponent<Text>().enabled = true;

            // Ocultar el texto
            else
                GetComponent<Text>().enabled = false;
        }
    }
}
