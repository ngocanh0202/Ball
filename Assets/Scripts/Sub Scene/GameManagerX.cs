using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI txt_time;
    public TextMeshProUGUI txt_score;
    
    public int second_time;
    public bool isGameActive;

    public GameObject Title_Start;
    public GameObject Title_Complete;
    public GameObject Title_Loose;
    // Start is called before the first frame update
    void Start()
    {
        txt_time.text = $"Second: {second_time}";
        txt_score.text = $"Score: {second_time}";
    }
    IEnumerator CooldownTime(){
        while(isGameActive){
            second_time--;
            txt_time.text = $"Second: {second_time}";
            if(second_time <= 0){
                
                LooseGame();
            }
            yield return new WaitForSeconds(1);
        }
    }
    public void UpdateTime(int time){
        second_time+= time;
    }
    
    public void StartGame(){
        isGameActive = true;
        StartCoroutine(CooldownTime());
        Title_Start.SetActive(false);
    }
    public void WinGame(){
        isGameActive = false;
        Title_Complete.SetActive(true);
        txt_score.text = $"Score: {second_time}";
    }
    public void LooseGame(){
        isGameActive = false;
        second_time = 0;
        txt_time.text = $"Second: {second_time}";
        Title_Loose.SetActive(true);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void RestartGame(){
        SceneManager.LoadScene("Sub Scene");
        GameObject player = GameObject.Find("PlayerX"); 
        PlayerControllerX playerController = player.GetComponent<PlayerControllerX>();
        playerController.isGround = true; 

        Physics.gravity = new Vector3(0, -9.81f, 0); // set gravity default
    }
    public void ReGameFromBegin(){
        SceneManager.LoadScene("Main Scene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
