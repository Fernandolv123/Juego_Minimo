using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private bool active =false;
    private float timer;
    private bool audioWasPlayed;

    public AudioClip chaseAudio;
    public AudioSource audio;

    [Header("Base Level")]
    public GameObject baseZombieRunPrefab;
    public Transform baseZombieSpawner;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        audioWasPlayed= false;
        audio = GameObject.FindGameObjectWithTag("SoundController").GetComponent<AudioSource>();
        chaseAudio = Resources.Load<AudioClip>("Audio/Hit_stress");
        //Debug.Log(chaseAudio);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (active){
                if (Time.time > timer+20){
                        //Debug.Log("Ha entrado correctamente");
                        if (!audioWasPlayed){
                            Instantiate(baseZombieRunPrefab,baseZombieSpawner.position,baseZombieSpawner.rotation);
                            audio.PlayOneShot(chaseAudio);
                            audioWasPlayed = true;
                        }
                    }
                } else {
           // Debug.Log("Reseteo el timer");
            timer = Time.time;
        }
    }

    public void Activate(){
        active = true;
    }
    public void DeActivate(){
        active = false;
    }

    public bool IsActive(){
        return active;
    }
}
