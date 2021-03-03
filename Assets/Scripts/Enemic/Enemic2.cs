using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemic2 : EnemicAI
{
    public int target;

    private void Update()
    {
        if (!GameManager.gameManager.gameOver)
        {
            TrackPlayer();
        }
        else
            enemicAgent.ResetPath();
    }

    protected override void TrackPlayer()
    {
        enemicAgent.SetDestination(players[target].transform.position);
    }
}
