using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemic1 : EnemicAI
{
    public Transform stay;

    void Update()
    {
        if (!GameManager.gameManager.gameOver)
        {
            if (Vector3.Distance(players[0].transform.position, stay.position) < 10f || Vector3.Distance(players[1].transform.position, stay.position) < 10f)
            {
                TrackPlayer();
            }
            else
                enemicAgent.SetDestination(stay.position);
        }
        else
            enemicAgent.ResetPath();
    }
}
