using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kontroler : MonoBehaviour
{
    

   
    public GameObject hazard;
    public Vector3 spawnValues;
    public float speed=1f;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public KretanjeMetka kretanjeMetka;

    public Text Score;
    public Text Restart;
    public Text GameOver;
    private int score;
    private bool restart;
    private bool gameOver;
    private string level;

    void Start ()
    {
        gameOver = false;
        restart = false;
        GameOver.text = "";
        Restart.text = "";

        score = 0;
        UpdateScore();
       StartCoroutine( SpawnWaves());
    }

    void Update()
    {
       
       // runningPlayer.transform.Translate(Vector3.left * change);
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Probica");
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                /*spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                spawnRotation = Quaternion.identity;
                Instantiate(hazard2, spawnPosition, spawnRotation);

                spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                spawnRotation = Quaternion.identity;
                Instantiate(hazard3, spawnPosition, spawnRotation);*/

                if (gameOver)
                {
                    Restart.text = "Press 'R' for Restart";
                    restart = true;
                    break;
                }
                   
                yield return new WaitForSeconds(startWait);
            }

            

       /*     yield return new WaitForSeconds(waveWait);
            for (int i = 0; i < hazardCount; i++)
            {
                
            }
            yield return new WaitForSeconds(waveWait);

            for (int i = 0; i < hazardCount; i++)
            {
               
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard2, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(startWait);
            }
          
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard3, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(startWait);
            }*/

            if (gameOver)
            {
                Restart.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

   public void UpdateScore()
    {

        Score.text = "Score:" + score;
    }
    public void Gameover()
    {
        GameOver.text = "Game Over!";
        gameOver = true;
    }

    public void increaseSpeed(float new_speed)
    {
        speed += (new_speed + 0.5f);
        Debug.Log(speed);
    }


}
