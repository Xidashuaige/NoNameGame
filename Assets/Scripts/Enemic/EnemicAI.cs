using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemicAI : MonoBehaviour
{
    public GameObject[] players;
    public SphereCollider weapon;
    public TrailRenderer weaponTrail;
    public float detectRange;

    protected NavMeshAgent enemicAgent;
    protected Animator enemicAnim;

    private void Awake()
    {
        enemicAgent = GetComponent<NavMeshAgent>();
        enemicAnim = GetComponent<Animator>();
    }

    protected virtual void TrackPlayer()
    {
        float disA = Vector3.Distance(transform.position, players[0].transform.position);
        float disB = Vector3.Distance(transform.position, players[1].transform.position);

        if (disA < detectRange || disB < detectRange)
        {
            int d = disA > disB ? 1 : 0;
            enemicAgent.SetDestination(players[d].transform.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!GameManager.gameManager.gameOver)
        {
            if (other.CompareTag("Player") && enemicAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Attack")
            {
                weaponTrail.startColor = Color.red;
                enemicAnim.SetTrigger("Attack");
                weapon.enabled = true;
            }
        }       
    }

    public void CloseAttackDetect()
    {
        weapon.enabled = false;
        weaponTrail.startColor = Color.white;
    }

}
