using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float startWait, spawnWait, waveWait;
    public Text scoreText, restartText, gameOverText;
    private short score;
    private bool restart, gameOver;

    void Start()
    {
        score = 0;
        gameOver = false;
        gameOverText.text = "";
        restartText.text = "";
        UpdateScore();
        StartCoroutine(SpawnSetup());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnSetup()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3
                    (
                        Random.Range(-spawnValues.x, spawnValues.x),
                        spawnValues.y,
                        spawnValues.z
                    );
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                break;
            }
        }
    }

    public void ShipDestroyed(bool newStatus)
    {
        restartText.text = "Press R to restart";
        restart = true;
        gameOverText.text = "GAME OVER";
        gameOver = newStatus;
    }

    public void AddScore(short scoreCount)
    {
        score += scoreCount;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}