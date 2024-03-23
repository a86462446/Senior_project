using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float moveSpeed= 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(moveSpeed* Time.deltaTime, 0, 0);
        }
        else if(Input.GetKey(KeyCode.S)){
            transform.Translate(-moveSpeed* Time.deltaTime, 0, 0);
        }
        else if(Input.GetKey(KeyCode.A)){
            transform.Translate(0, 0, moveSpeed* Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Translate(0, 0, -moveSpeed* Time.deltaTime);
        }
    }
}
