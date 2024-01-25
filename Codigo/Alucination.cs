using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alucination : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        
        if (other.gameObject.name=="ZombieKiller"){
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag=="Player"){
            Debug.Log("Enter");
            GameManager.instance.die = true;
        }
    }
    void OnCollisionEnter(Collision other){

    }
}
