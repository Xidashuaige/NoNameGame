using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamVisible : MonoBehaviour
{
    public GameObject player;

    private GameObject wall;
    private int thisID, otherID;

    private void Start()
    {
        thisID = player.GetComponent<Player>().playerID;
        // Comparar para saber ID de cada persona
        otherID = thisID > otherID ? 0 : 1;
    }

    void Update()
    {
        RaycastHit hit;
        Ray cnmRay = new Ray(transform.position, player.transform.position - transform.position + (Vector3.up * 0.5f));

        // Dibujar el rayo en la pantalla de Scene
        Debug.DrawRay(transform.position, player.transform.position - transform.position + (Vector3.up * 0.5f), Color.red);

        if (Physics.Raycast(cnmRay, out hit)) // lanzar un rayo deste la camara hacia el player
        {
            if (hit.collider.CompareTag("Wall")) // Para detectar si la pared ha ocultado el player o no
            {
                // Marcar como estar en el rango de pared
                hit.collider.gameObject.GetComponent<WallManager>().playersInRange[thisID] = true;
                // compara para saber si es una pared nueva o es la de antes
                if (hit.collider.gameObject != wall)
                {
                    // Resetear informacion de la pared anteriol
                    if (wall != null)
                        wall.GetComponent<WallManager>().playersInRange[thisID] = false;
                    ChangeWallTrans(1, 1);

                    // Guardar informacion de la pared actual
                    wall = hit.collider.gameObject;
                }

                // Si otro jugador no esta en el rango de pared.
                if (!hit.collider.gameObject.GetComponent<WallManager>().playersInRange[otherID])
                {                   
                    ChangeWallTrans(0.5f, 0.3f);
                }
            }
            else
            {
                ChangeWallTrans(1, 1);
                if (wall != null)
                {
                    // Marcar que el player ya no esta en este pared.
                    wall.GetComponent<WallManager>().playersInRange[thisID] = false;
                }               
            }
        }      
    }

    /// <summary>
    /// Cambiar valor alpha de pared
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="trans"></param>
    private void ChangeWallTrans(float clip,float trans)
    {
        if (wall != null && !wall.GetComponent<WallManager>().playersInRange[otherID])
        {
            wall.transform.Find("wallObject").GetComponent<MeshRenderer>().material.SetFloat("_Clipping_Level", clip);
            wall.transform.Find("wallObject").GetComponent<MeshRenderer>().material.SetFloat("_Tweak_transparency", trans);

            wall.transform.Find("pCube3").GetComponent<MeshRenderer>().material.SetFloat("_Clipping_Level", clip);
            wall.transform.Find("pCube3").GetComponent<MeshRenderer>().material.SetFloat("_Tweak_transparency", trans);
        }
    }
}
