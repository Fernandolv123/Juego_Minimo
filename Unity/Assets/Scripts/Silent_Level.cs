using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Silent_Level : Level
{
    private float silentTimer;
    private bool audioWasPlayedSilent;
    public GameObject zombieRunPrefab;
    public GameObject zombieRunSpawner;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        audioWasPlayedSilent = false;
        silentTimer = Time.time;
    }

    // Update is called once per frame
    protected override void Update()
    {
        //Debug.Log(Time.time+" | "+timer);
        //base.Update();
        if (base.IsActive()){
            GameManager.instance.ManagerAudioSource().Pause();
            if (Time.time > silentTimer + 4f){
                if(!audioWasPlayedSilent){
                audio.PlayOneShot(chaseAudio);
                Instantiate(zombieRunPrefab,zombieRunSpawner.transform.position,zombieRunSpawner.transform.rotation);
                audioWasPlayedSilent = true;
                }
            }
        } else {
            silentTimer = Time.time;
        }
    }
}
