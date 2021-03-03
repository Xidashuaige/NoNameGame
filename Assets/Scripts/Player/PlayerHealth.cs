using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector] public int health;
    public const int _MaxHealth = 3;
    public GameObject[] healthUI;

    private bool protecPlayer = false;
    private ParticleSystem dieParicle;

    private void Awake()
    {
        dieParicle = transform.Find("DieParticle").GetComponent<ParticleSystem>();
        dieParicle.Stop();
    }

    private void Start()
    {             
        health = _MaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!GameManager.gameManager.gameOver)
        {
            if (other.CompareTag("EnemicAttack"))
            {
                Injure();
            }
        }        
    }

    /// <summary>
    /// Recibir daño
    /// </summary>
    private void Injure()
    {
        if ((!protecPlayer))
        {
            // Si tiene escudo, utiliza escudo para defensarlo
            if (transform.Find("Shield").gameObject.activeInHierarchy)
            {
                GetComponent<PlayerShield>().CloseShield();
            }
               
            else
            {
                health--;
                healthUI[health].SetActive(false);
                if (health <= 0)
                {
                    Die();
                }
                else
                {
                    SoundsManager.soundsManager.PlayAudio(Audios.Injured);
                }
            }

            // Poner un proteccion al jugador para que no reciba el daño mas de una vez
            protecPlayer = true;
            Invoke(nameof(DesProtect), 0.5f);
        }        
    }

    /// <summary>
    /// Morir
    /// </summary>
    private void Die()
    {        
        GameManager.gameManager.GameOver(GetComponent<Player>().playerID);
        SoundsManager.soundsManager.PlayAudio(Audios.Die);
        dieParicle.Play();
        dieParicle.transform.SetParent(null);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Cerrar el proteccion
    /// </summary>
    private void DesProtect()
    {
        protecPlayer = false;
    }
}
