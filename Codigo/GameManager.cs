using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<AudioClip> ambientalAudio;
    public List<AudioClip> noiseAudioClip;
    public AudioClip chaseAudio;
    private AudioSource audio;
    private float timer;

    void Awake() {
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        StartCoroutine("RandomNoise");
        audio.PlayOneShot(ambientalAudio[0]);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time+"//"+(timer+10));
        if (Time.time > timer+10){
            Debug.Log("entra");
            audio.PlayOneShot(chaseAudio);
        }
        
    }

    IEnumerator RandomNoise(){
        while(true){
            if (Random.Range(0,10) < 1){
                audio.PlayOneShot(noiseAudioClip[Random.Range(0,noiseAudioClip.Count)]);
                yield return new WaitForSeconds(10f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
