using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackCollider : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Entra || "+other);
        if (other.gameObject.tag=="Enemies"){
            Debug.Log("Entra");
            //player.GetComponent<Player>().StartCoroutine("Turning");
        }
    }
}
