using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gimmick_Zombie_Run : MonoBehaviour
{
    public GameObject alucinationPrefab;
    public Transform alucinationSpawn;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Instantiate(alucinationPrefab,alucinationSpawn.position,alucinationSpawn.rotation);
        }
    }

    void OnTriggerExit (Collider other){
        Destroy(this.gameObject);
    }
}
