using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RailingController : MonoBehaviour
{
    [HideInInspector] public bool[] playersInRange = new bool[3];
    public Animator[] switchAnims;
    public Text[] switchTexts;

    public void OpenRailing()
    {
        // Revisar si todos los botones estan pulsado o no
        for(int i = 0; i < switchAnims.Length; i++)
        {
            if (!switchAnims[i].GetBool("Push"))
                return;
        }
        
        // Cambiar letras de boton 
        for(int i =0; i < switchTexts.Length; i++)
        {
            // Cambiar el aviso de boton
            switchTexts[i].text = "The railing is open!";            
        }

        // Despulsarl los botones
        for (int i = 0; i < switchAnims.Length; i++)
        {
            switchAnims[i].SetBool("Push", false);
        }

        // Mostrar las letra de boton
        GameObject[] ss = GameObject.FindGameObjectsWithTag("Switch");
        foreach (var s in ss)
        {
            s.GetComponent<SwitchController>().canPush = true;
        }

        // Cerrar las cuenta atras de boton
        GameObject[] gs = GameObject.FindGameObjectsWithTag("Sliders");
        foreach (var g in gs)
        {
            g.GetComponent<SwitchSlider>().switchSlider.value = 0;
            g.GetComponent<SwitchSlider>().CloseCount();
        }

        // Ocultar flechas de indicacioes 
        GameObject[] ars = GameObject.FindGameObjectsWithTag("Arrow");
        foreach (var a in ars)
        {
            a.GetComponent<ArrownController>().CloseArrown();
        }

        // Destruir la puerta
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersInRange[other.GetComponent<Player>().playerID] = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersInRange[other.GetComponent<Player>().playerID] = false;
        }
    }
}
