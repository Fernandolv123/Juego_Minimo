using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gimmick_Zombie_Run : MonoBehaviour
{
    public GameObject alucinationPrefab;
    public Transform alucinationSpawn;
    public AudioClip spawnAudio;
    private AudioSource audio;

    void Start(){
        audio = GameObject.FindGameObjectWithTag("SoundController").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player")){
            Instantiate(alucinationPrefab,alucinationSpawn.position,alucinationSpawn.rotation);
            audio.PlayOneShot(spawnAudio);
        }
    }

    void OnTriggerExit (Collider other){
        Destroy(this.gameObject);
    }
}
