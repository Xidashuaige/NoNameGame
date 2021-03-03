using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{   
    public bool canPush = false;
    public RailingController railingController;
    public int switchNum;
    public SwitchSlider[] switchSliders;
    public ArrownController[] arrownControllers;
    [HideInInspector]public bool[] playersInRange = new bool[3];
    [HideInInspector]public Animator switchAnim;
    
    void Start()
    {
        switchAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canPush && railingController != null) 
        {
            if (playersInRange[0] && Input.GetKeyDown(KeyCode.E) || playersInRange[1] && Input.GetKeyDown(KeyCode.L))
            {
                SoundsManager.soundsManager.PlayAudio(Audios.SwitchFeedBack);
                switchAnim.SetBool("Push", true);
                canPush = false;
                // Resetear el boton despues de 2 segundos
                Invoke(nameof(ResetSwitch), 5f);

                // Empezar el cuento atras de boton
                for (int i = 0; i < switchSliders.Length; i++)
                {
                    switchSliders[i].StartCount(switchNum);
                }

                // Mostrar flecha de aviso
                for (int i = 0; i < arrownControllers.Length; i++)
                {
                    arrownControllers[i].ShowArrown();
                }
               
                // Abrir la puerta/barandilla
                railingController.OpenRailing();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si hay jugador ha entrado en el rango
        if (other.CompareTag("Player"))
        {
            // Si el boton no esta pulsado
            if (!switchAnim.GetBool("Push")) 
            // Cambiar estado de poder pulsar en true
            canPush = true;

            // Poner el jugador dentro de la lista del rango.
            playersInRange[other.GetComponent<Player>().playerID] = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el objeto que sale es jugador
        if (other.CompareTag("Player"))
        {
            // Comparar para saber el ID de cada jugador
            int p1 = other.GetComponent<Player>().playerID;
            int p2 = 0;
            p2= p1 > p2 ? 0 : 1;

            // Si otro jugador no esta en el rango
            if(!playersInRange[p2])
            // Ya no se puede pulsar
            canPush = false;

            // Sacar jugador fuera de la lista
            playersInRange[other.GetComponent<Player>().playerID] = false;
        }
    }

    /// <summary>
    /// Resetear el boton
    /// </summary>
    private void ResetSwitch()
    {
        switchAnim.SetBool("Push", false);
        if(railingController != null)
        SoundsManager.soundsManager.PlayAudio(Audios.SwitchFeedBack);
        // Si aun queda algun jugador en el rango
        if (playersInRange[0] || playersInRange[1]) 
        {           
            // Poner el poder pulsar en true
            canPush = true;
        }
    }
}
