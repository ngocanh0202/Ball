using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public float zLimitAxis;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive){
            PlayerInput();
            CheckZAxis();
        }
    }
    void CheckZAxis(){
        if(transform.position.z > zLimitAxis){
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimitAxis);
        }
        else if(transform.position.z < -zLimitAxis){
            transform.position = new Vector3(transform.position.x, transform.position.y, -zLimitAxis);
        }
    }
    void PlayerInput(){
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(speed * horizontalInput * Vector3.left);
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Ball")){
            Destroy(other.gameObject);
            gameManager.updateScore(5);
        }
    }
}
