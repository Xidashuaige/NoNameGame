using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawn : MonoBehaviour
{
    public GameObject gold;
    public Animator PromptAnim;

    private List<Transform> spawnTrans = new List<Transform>();
    private List<GameObject> golds = new List<GameObject>();

    void Start()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Lamp");

        for (int i = 0; i < g.Length; i++)
        {
            spawnTrans.Add(g[i].transform);
        }
        InitGold();
    }

    /// <summary>
    /// Resetear monedas
    /// </summary>
    public void ResetGolds()
    {
        for (int i = 0; i < golds.Count; i++)
        {
            if (golds[i] != null)
            {
                return;
            }
        }
        SoundsManager.soundsManager.PlayAudio(Audios.Prompt);
        PromptAnim.SetTrigger("PromptIn");
        SpawnGold();
    }

    /// <summary>
    /// Inicializar monedas
    /// </summary>
    private void InitGold()
    {
        for (int i = 0; i < spawnTrans.Count; i++) 
        {
            golds.Add(Instantiate(gold, spawnTrans[i]));
            golds[i].transform.localPosition = new Vector3(-1.5f, 1, 0);
        }
    }

    /// <summary>
    /// Crear mas monedas
    /// </summary>
    private void SpawnGold()
    {
        int[] randoms = new int[5];
        for(int i = 0; i < 5; i++)
        {
            randoms[i] =Random.Range(0, 7);
            if (i != 0)
            {
                while(randoms[i] == randoms[i - 1])
                {
                    randoms[i] = Random.Range(0, 7);
                }
            }

            golds[randoms[i]] = Instantiate(gold, spawnTrans[randoms[i]]);
            golds[randoms[i]].transform.localPosition = new Vector3(-1.5f, 1, 0);
        }
    }
}
