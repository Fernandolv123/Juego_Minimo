using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int level;
    private bool playerRunning = false;
    private bool playerWalking = false;
    public bool die = false;
    public GameObject playerPrefab;
    public List<GameObject> levelSelector;
    public List<AudioClip> ambientalAudio;
    public List<AudioClip> noiseAudioClip;
    public AudioClip chaseAudio;
    public static GameManager instance;
    private AudioSource audio;
    private float timer;

    private GameObject newlevel;

    void Awake() {
        instance = this;
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //timer = Time.time;
        //StartCoroutine("RandomNoise");
        audio.PlayOneShot(ambientalAudio[0]);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in levelSelector){
            //Debug.Log(go.GetComponent<Level>().IsActive());
        }
        if(die){
            //Debug.Log("Entra aqui tambien");
            playerPrefab.gameObject.GetComponent<Player>().Die();
            //Destroy(playerPrefab.gameObject.GetComponent<Player>());
        }
        //Debug.Log(Time.time+"//"+(timer+10));
        //if (Time.time > timer+10){
            //Debug.Log("entra");
        //    audio.PlayOneShot(chaseAudio);
        //}
        
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

    public void NextLevel(){ 
        if (newlevel != null) {
            newlevel.GetComponent<Level>().DeActivate();
            levelSelector.Remove(newlevel);
        }
        newlevel = levelSelector[Random.Range(0,levelSelector.Count)];
        playerPrefab.transform.position = newlevel.transform.Find("PlayerSpawner").transform.position;
        playerPrefab.transform.rotation = newlevel.transform.Find("PlayerSpawner").transform.rotation;
        playerPrefab.GetComponent<Player>().ResetPosition();
        newlevel.GetComponent<Level>().Activate();


        //level ++;
        //debemos guardar una referencia al pasillo anterior para desactivarlo y que no presente problemas
                /*if (debug ==1){
            levelSelector[0].GetComponent<Level>().DeActivate();
        playerPrefab.transform.position = levelSelector[1].transform.Find("PlayerSpawner").transform.position;
        playerPrefab.transform.rotation = levelSelector[1].transform.Find("PlayerSpawner").transform.rotation;
        playerPrefab.GetComponent<Player>().ResetPosition();
        levelSelector[1].GetComponent<Level>().Activate();
        } else {
        playerPrefab.transform.position = levelSelector[0].transform.Find("PlayerSpawner").transform.position;
        playerPrefab.transform.rotation = levelSelector[0].transform.Find("PlayerSpawner").transform.rotation;
        playerPrefab.GetComponent<Player>().ResetPosition();
        //Instantiate(playerPrefab,levelSelector[0].transform.Find("PlayerSpawner").position,Quaternion.identity);
        //Destroy(GameObject.FindGameObjectWithTag("Player"));
        levelSelector[0].GetComponent<Level>().Activate();
        debug ++;
                }*/

        //Probar funcionalidad de esto
        audio.Play();
    }

    public AudioSource ManagerAudioSource(){
        return audio;
    }

    public bool PlayerRunning(){
        return playerRunning;
    }
    public bool PlayerWalking(){
        return playerWalking;
    }

    public void PlayerChangeState(bool running,bool walking){
        playerRunning = running;
        playerWalking = walking;
    }
}
