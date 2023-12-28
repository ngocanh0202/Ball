using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI txt_score;
    public int score;
    public bool isGameActive;
    private SpawnBall spawnBall;
    public GameObject titleGame;
    public GameObject titleGameOver;
    public GameObject titleGameWin;

    public float delaySpawnCooldown; //
    public float speedBallFall;

    private bool hasIncreasedSpeed30 = false;
    private bool hasIncreasedSpeed50 = false;
    private bool hasIncreasedSpeed70 = false;


    // Start is called before the first frame update
    void Start()
    {
        txt_score.text = "Score: 0/100";
        spawnBall = GameObject.Find("SpawnBall").GetComponent<SpawnBall>();

    }

    // Update is called once per frame
    void Update()
    {
        if(score == 30 && !hasIncreasedSpeed30){
            speedBallFall += 100;
            delaySpawnCooldown /= 1.5f;
            hasIncreasedSpeed30 = true;
        }
        else if(score == 50 && !hasIncreasedSpeed50){
            speedBallFall += 50;
            delaySpawnCooldown /= 1.5f;
            hasIncreasedSpeed50 = true;
        }
        else if(score == 70 && !hasIncreasedSpeed70){
            speedBallFall += 50;
            hasIncreasedSpeed70 = true;
        }
        else if(score >= 100){
            WinGame();
        }
    }
    public void WinGame(){
        isGameActive = false;
        titleGameWin.SetActive(true);
        GameObject[] ballspawned = GameObject.FindGameObjectsWithTag("Ball");
        for(int i = 0 ; i < ballspawned.Length ; i ++){
            Destroy(ballspawned[i]);
        }
    }
    public void StartGame(){
        isGameActive = true;
        spawnBall.GameStart();
        titleGame.SetActive(false);
    }
    public void GameOver(){
        isGameActive = false;
        titleGameOver.SetActive(true);

        GameObject[] ballspawned = GameObject.FindGameObjectsWithTag("Ball");
        for(int i = 0 ; i < ballspawned.Length ; i ++){
            Destroy(ballspawned[i]);
        }
    }
    public void ReStartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextScene(){
        SceneManager.LoadScene("Sub Scene");
        Physics.gravity = new Vector3(0, -9.81f, 0); 
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void updateScore(int scoreUpdate){
        score += scoreUpdate;
        txt_score.text = $"Score: {score}/100";
    }
}
