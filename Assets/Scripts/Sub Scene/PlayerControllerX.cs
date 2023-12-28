using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private Rigidbody playerRigid;
    public float xLimitAxis;
    public float zLimitAxis;
    public float setGravity;
    public float zHighest;
    public bool isGround = true;
    private GameManagerX gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        Physics.gravity *= setGravity;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive){
            UserInput();
        }else{
            transform.position = new Vector3(0, 0.337f,0);
        }
        CheckXAxis();
        
    }
    void UserInput(){
        float verticalInput = Input.GetAxis("Vertical");
        playerRigid.AddForce(Vector3.forward * verticalInput * speed * Time.deltaTime, ForceMode.Impulse);

        float horizontalInput = Input.GetAxis("Horizontal");
        playerRigid.AddForce(Vector3.right * horizontalInput * speed * Time.deltaTime, ForceMode.Impulse);

        if(Input.GetKeyDown(KeyCode.Space) && isGround){
            playerRigid.AddForce(Vector3.up  * jumpPower, ForceMode.Impulse);
            // Debug.Log("Jump Power: " + jumpPower);
            Debug.Log("Physics" + Physics.gravity);
            isGround = false;
        }
    }
    void CheckXAxis(){
        if(transform.position.x > xLimitAxis){
            transform.position = new Vector3(xLimitAxis, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -xLimitAxis){
            transform.position = new Vector3(-xLimitAxis, transform.position.y, transform.position.z);
        }
        else if(transform.position.z < zLimitAxis){
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimitAxis);
        }
        else if(transform.position.z > zHighest){
            transform.position = new Vector3(transform.position.x, transform.position.y, zHighest);
        }
        else if(transform.position.y < -0.5){
            gameManager.LooseGame();
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Goal")){
            //Debug.Log($"WIN GAME");
            gameManager.WinGame();
        }
        
    }
    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("road")){
            isGround = true;
            //Debug.Log($"Ground: {isGround}");
        }
        else if(other.gameObject.CompareTag("Ob")){
            gameManager.UpdateTime(-5);
        }
        
    }
}
