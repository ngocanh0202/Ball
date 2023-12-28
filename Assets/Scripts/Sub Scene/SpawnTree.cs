using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTree : MonoBehaviour
{
    // Z : 5 - > 115
    // X : -2 - > 2
    public GameObject []arrow;
    public float zLowest;
    public float yHighest;
    public float zHighest;
    public float xLimit;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnTreeZToZ",0,1);
        SpawnTreeZToZ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnTreeZToZ(){
        for(float i = zLowest; i < zHighest; i+=5){
            int index = Random.Range(0, arrow.Length);
            Instantiate(arrow[index], randomPosition(i), arrow[index].transform.rotation);
        }
    }
    Vector3 randomPosition(float z){
        float i = Random.Range(-xLimit, xLimit);
        return new Vector3(i,yHighest, z);
    }
}
