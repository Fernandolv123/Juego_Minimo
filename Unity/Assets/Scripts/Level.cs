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
            //Debug.Log("Estoy Activo"); 21:05
                if (Time.time > timer+30){
                        //Debug.Log("Ha entrado correctamente");
                        audio.PlayOneShot(chaseAudio);
                        audioWasPlayed = true;
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
