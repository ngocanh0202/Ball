using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BallFall : MonoBehaviour
{
    public float yLimitAxis;
    private GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yLimitAxis){
            Destroy(gameObject);
            gameManager.isGameActive = false;
            gameManager.GameOver();
        }
        if(gameManager.isGameActive){
            Debug.Log("Speed: " + gameManager.speedBallFall);
            transform.Translate(Vector3.down * gameManager.speedBallFall * Time.deltaTime);
        }
    }
    
}
