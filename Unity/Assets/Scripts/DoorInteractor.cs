using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorInteractor : MonoBehaviour
{
    private bool nextLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            //poner canvas
            if (nextLevel){
                GameManager.instance.NextLevel();
                //Debug.Log("Siguiente nivel");
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Finish")){
            nextLevel = true;
        }
    }
    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Finish")){
            nextLevel = false;
        }
    }
}
