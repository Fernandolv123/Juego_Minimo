using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DoorInteractor : MonoBehaviour
{
    private bool nextLevel = false;
    private Text doorInitializer;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        doorInitializer = GameObject.FindGameObjectWithTag("DoorController").GetComponent<Text>();
    }
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
            doorInitializer.enabled = true;
        } else if (other.gameObject.CompareTag("FakeWall")){
            
        }
    }
    void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Finish")){
            nextLevel = false;
            doorInitializer.enabled = false;
        }
    }
}
