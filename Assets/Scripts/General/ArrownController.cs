using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrownController : MonoBehaviour
{
    public GameObject[] switchs;
    public Transform player;
    public Vector3 offset;
    public float speed;

    private int targetNum;

    void Update()
    {        
        // Disparar Hacia el destinatario
        Vector3 dir = Vector3.Normalize(switchs[targetNum].transform.position - transform.position);
        Vector3 direc = new Vector3(dir.x, 0, dir.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direc), speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // Seguir al player
        transform.position = player.position + offset;
    }

    public void ShowArrown()
    {
        transform.Find("ArrowImg").GetComponent<Image>().enabled = true;
        Invoke(nameof(CloseArrown), 5f);

        for (int i = 0; i < switchs.Length; i++)
        {
            if (!switchs[i].GetComponent<SwitchController>().switchAnim.GetBool("Push")) 
            {
                targetNum = i;
            }
        }
    }

    public void CloseArrown()
    {
        transform.Find("ArrowImg").GetComponent<Image>().enabled = false;
    }
}
