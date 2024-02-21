using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gimmick_Zombie_Run : MonoBehaviour
{
    public GameObject alucinationPrefab;
    public Transform alucinationSpawn;
    public AudioClip spawnAudio;
    public GameObject zombieDestroyer;
    private AudioSource audio;
    private bool safeSpot=true;

    void Start(){
        audio = GameObject.FindGameObjectWithTag("SoundController").GetComponent<AudioSource>();
    }
    void Update(){
        if (!safeSpot){
            if(Input.GetKeyDown(KeyCode.S)){
                Destroy(zombieDestroyer);
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Instantiate(alucinationPrefab,alucinationSpawn.position,alucinationSpawn.rotation);
            audio.PlayOneShot(spawnAudio);
            safeSpot=false;
        }
    }

    void OnTriggerExit (Collider other){
        Destroy(this.gameObject);
    }
}
