using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{  
    public bool[] playersInRange = new bool[3];
    public Texture[] wallTextures;

    void Start()
    {
        // Inicializar paredes, asignar grafitis aleatoreas al pared.
        int t = Random.Range(0, 10);
        transform.Find("wallObject").GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", wallTextures[t]);
        transform.Find("wallObject").GetComponent<MeshRenderer>().material.SetTexture("_1st_ShadeMap", wallTextures[t]);   
    }
}
