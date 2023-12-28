using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehivor : MonoBehaviour
{
    public GameObject player;
    private Vector3 setCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        setCameraPosition = new Vector3(0,4.45f,-4.5f);
    }


    void LateUpdate()
    {
        transform.position = player.transform.position + setCameraPosition;
    }
}
