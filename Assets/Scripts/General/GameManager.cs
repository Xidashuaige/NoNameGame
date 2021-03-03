using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public static GameManager gameManager = null;
    public GameObject resetBtn;
    public GameObject startBtn;
    public GameObject exitBtn;
    public Text[] resultTexts;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameOver = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!exitBtn.activeInHierarchy)
            {
                exitBtn.SetActive(true);
                Invoke(nameof(CloseExitBtn), 3f);
            }            
        }
    }

    /// <summary>
    /// Empezar el juego
    /// </summary>
    public void StartGame()
    {
        gameOver = false;
        startBtn.SetActive(false);
    }

    /// <summary>
    /// Terminar el juego cuando alguien muere
    /// </summary>
    /// <param name="playerID"></param>
    public void GameOver(int playerID)
    {
        gameOver = true;
        resetBtn.SetActive(true);

        int o = playerID > 0 ? 0 : 1;

        resultTexts[o].text = "WIN";
        resultTexts[playerID].text = "LOSE";
        SoundsManager.soundsManager.PlayAudio(Audios.GameOver);
    }

    /// <summary>
    /// Terminar el juego cuando tiempo se acaba
    /// </summary>
    public void GameOver()
    {
        gameOver = true;
        resetBtn.SetActive(true);
        SoundsManager.soundsManager.PlayAudio(Audios.GameOver);

        int s1 = ScoreManager.scoreManager.scores[0];
        int s2 = ScoreManager.scoreManager.scores[1];

        if (s1 > s2)
        {
            resultTexts[0].text = "WIN";
            resultTexts[1].text = "LOSE";
        }
        else if (s1 < s2)
        {
            resultTexts[0].text = "LOSE";
            resultTexts[1].text = "WIN";
        }
        else
        {
            resultTexts[0].text = "DRAW";
            resultTexts[1].text = "DRAW";
        }
    }

    /// <summary>
    /// Recetear la partida
    /// </summary>
    public void ResetGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// Cerrar el juego
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Ocultar el boton de salir
    /// </summary>
    private void CloseExitBtn()
    {
        exitBtn.SetActive(false);
    }
}
