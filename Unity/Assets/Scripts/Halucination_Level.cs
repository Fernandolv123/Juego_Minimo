using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Halucination_Level : Level
{
    [Header("Level")]
    public GameObject spriteHalucination;
    public GameObject playerPrefab;
    public GameObject frontCanavas;
    public GameObject backCanvas;
    public GameObject dieCanvas;
    public AudioClip audioMuerte;
    public AudioClip audioSpawn;

    private bool safepoint;
    private AudioSource audioController;
    private Image canvasImage;
    private bool alreadySpawned = false;
    private bool playerLooking = true;
    private float timerLookingBack;
    private bool firstTime=true;
    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();
        canvasImage = frontCanavas.GetComponentInChildren<Image>();
        StartCoroutine("CanvasImageSelector");
        //StartCoroutine("CanvasImageSpawner");
        audioController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        //base.Update();
        if (base.IsActive()) {
            if (Input.GetKeyDown(KeyCode.S)){
                safepoint=!safepoint;
                playerLooking=!playerLooking;
            }
            if (!playerLooking){
                if(Time.time > timerLookingBack+7f){
                    if(firstTime){
                        dieCanvas.GetComponent<Canvas>().enabled = true;
                        audioController.PlayOneShot(audioMuerte);
                        Invoke("Die",1f);
                        firstTime = false;
                    }
                }
            } else {
                timerLookingBack = Time.time;
            }
            frontCanavas.GetComponent<Transform>().position = new Vector3(playerPrefab.transform.position.x,playerPrefab.transform.position.y+1, playerPrefab.transform.position.z + 3);
            backCanvas.GetComponent<RectTransform>().position = new Vector3(playerPrefab.transform.position.x, playerPrefab.transform.position.y+1, playerPrefab.transform.position.z - 5);
            //frontCanavas.GetComponent<RectTransform>().position.z = playerPrefab.transform.position.z+5;
        }
    }

    IEnumerator CanvasImageSelector() {
        while (true) {
            yield return null;
            if (base.IsActive()) {
                yield return new WaitForSeconds(1.2f);
                int random = Random.Range(0, 1000);
                if (random >= 500 && !alreadySpawned && playerLooking) {
                    alreadySpawned = true;
                    safepoint = false;
                    StartCoroutine("CanvasImageSpawner");
                }
            }
        }
    }

    IEnumerator CanvasImageSpawner() {
            for (float i = 0; i <= 1f; i += Time.deltaTime*4)
            {
                if (i < 1){
                    canvasImage.color = new Color(canvasImage.color.r, canvasImage.color.g, canvasImage.color.b, i);
                }
                yield return new WaitForSeconds(0.05f);
                if (safepoint){
                    break;
                }
            }

            if (safepoint){
                Invoke("ResetImage",2f);
            }

            while(safepoint){
                yield return null;
            }
            if (base.IsActive()){
                dieCanvas.GetComponent<Canvas>().enabled = true;
                audioController.PlayOneShot(audioMuerte);
                Invoke("Die",1f);
            }

        
    }
    public void ResetImage(){
        frontCanavas.GetComponent<AudioSource>().Play();
        safepoint=false;
        canvasImage.color = new Color(canvasImage.color.r, canvasImage.color.g, canvasImage.color.b, 0);
        StopCoroutine("CanvasImageSpawner");
        Invoke("ReadyForSpawn",4f);
    }
    public void ReadyForSpawn(){
        alreadySpawned = false;
    }

    IEnumerator FadeOut() {
        yield return new WaitForSeconds(1f);
        Image img =dieCanvas.GetComponentInChildren<Image>();
        for (float i = 1; i >= 0; i -= Time.deltaTime*4)
        {
            if (i < 1){
                img.color = new Color(img.color.r, img.color.g, img.color.b, i);        
            }
            yield return new WaitForSeconds(0.05f);

        }
        dieCanvas.active =false;
    }

    public void Die(){
        StartCoroutine("FadeOut");
        GameManager.instance.die=true;
    }
}
