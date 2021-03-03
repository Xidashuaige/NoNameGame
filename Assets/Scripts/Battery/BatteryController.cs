using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    [HideInInspector] public bool[] playersInRange = new bool[3];
    public PlayerShield[] playerShields;

    private void Update()
    {
        if (!GameManager.gameManager.gameOver)
        {
            if (Input.GetKeyDown(KeyCode.E) && playersInRange[0])
            {
                playerShields[0].OpenShield();
            }
            else if (Input.GetKeyDown(KeyCode.L) && playersInRange[1])
            {
                playerShields[1].OpenShield();
            }
        }        
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
