using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public List<GameObject> balls;
    public float zLimitAxis; // default
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void GameStart(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnBallWithTime());
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public IEnumerator SpawnBallWithTime(){
        while(gameManager.isGameActive){
            Debug.Log($"Secondary spawn: {gameManager.delaySpawnCooldown}");
            SpawnBallWithObject();
            yield return new WaitForSeconds(gameManager.delaySpawnCooldown);   
        }
    }
    public void SpawnBallWithObject(){
        int index = Random.Range(0, balls.Count);
        Instantiate(balls[index],RandomPosition(), balls[index].transform.rotation);
    }
    Vector3 RandomPosition(){
        float zAxis = Random.Range(-zLimitAxis, zLimitAxis);
        return new Vector3(transform.position.x, transform.position.y, zAxis);
    }
}
