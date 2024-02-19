using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool aboutToDie = false;
    private int level;
    private bool playerRunning = false;
    private bool playerWalking = false;
    public bool die = false;
    public GameObject playerPrefab;
    public List<GameObject> levelSelector;
    public List<AudioClip> ambientalAudio;
    public List<AudioClip> noiseAudioClip;
    public AudioClip openDoor;
    public AudioClip closeDoor;
    public static GameManager instance;
    private AudioSource audio;
    private AudioSource audioController;
    private float levelsWon=0;
    [Header("Related to UI")]
    [SerializeField]
    private GameObject rulesButton;
    [SerializeField]
    private GameObject buttonRulesText;
    [SerializeField]
    private List<AudioClip> audiosPaper;
    [SerializeField]
    private GameObject paperRules;
    [SerializeField]
    private List<Sprite> rulesButtonSprite;
    private GameObject newlevel;

    void Awake() {
        audioController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<AudioSource>();
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
        if (levelsWon == 0){
            rulesButton.active = true;
        } else {
            rulesButton.active = false;
            paperRules.active = false;
            //rulesText.enabled = false;
        }
        if(die){
            playerPrefab.gameObject.GetComponent<Player>().Die();
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

    public void NextLevel(){
        levelsWon++;
        if (newlevel != null) {
            newlevel.GetComponent<Level>().DeActivate();
            levelSelector.Remove(newlevel);
        }
        if (levelSelector.Count == 0){
            SceneManager.LoadScene("Win_Scene");
            return;
        }
        audioController.PlayOneShot(openDoor);
        Invoke("CloseDoor",0.4f);
        newlevel = levelSelector[Random.Range(0,levelSelector.Count)];
        playerPrefab.transform.position = newlevel.transform.Find("PlayerSpawner").transform.position;
        playerPrefab.transform.rotation = newlevel.transform.Find("PlayerSpawner").transform.rotation;
        playerPrefab.GetComponent<Player>().ResetPosition();
        newlevel.GetComponent<Level>().Activate();

        audio.Play();
    }

    public void CloseDoor(){
        audioController.PlayOneShot(closeDoor);
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

    public void OnRulesButtonClick(){
        if (/*!rulesText.enabled*/!paperRules.active){
            buttonRulesText.GetComponent<Text>().text = "Hide Rules";
            buttonRulesText.GetComponent<Transform>().localPosition = new Vector3(0,80,0);
            rulesButton.GetComponent<Image>().sprite = rulesButtonSprite[1];
            rulesButton.GetComponent<Button>().interactable = false;
            StartCoroutine("AppearPaper");
            //rulesText.enabled = true;
        } else {
            buttonRulesText.GetComponent<Text>().text = "Show Rules";
            buttonRulesText.GetComponent<Transform>().localPosition = new Vector3(0,0,0);
            rulesButton.GetComponent<Image>().sprite = rulesButtonSprite[0];
            rulesButton.GetComponent<Button>().interactable = false;
            //rulesText.enabled = false;
            StartCoroutine("DisppearPaper");

        }
        
    }
    IEnumerator AppearPaper() {
        paperRules.active = true;
        
        audio.PlayOneShot(audiosPaper[0]);
        //Esto provoca errores debido a la posicion en la que se encuentra dentro del canvas por lo que debemos restar esta position a la position máxima
        for (float i=-1000;i<=-310;i+=32){
            Debug.Log("valor i: "+i);
            paperRules.GetComponent<RectTransform>().localPosition = new Vector3(0,i,0);
            yield return new WaitForSeconds(0.001f);
        }
        Debug.Log("Entra aqui");
        paperRules.GetComponent<RectTransform>().localPosition = new Vector3(0,-310,0);
        rulesButton.GetComponent<Button>().interactable = true;
        yield return null;
    }

    IEnumerator DisppearPaper() {
        audio.PlayOneShot(audiosPaper[1]);
        for (float i=-310;i>=-1000;i-=32){
            paperRules.GetComponent<RectTransform>().localPosition = new Vector3(0,i,0);
            yield return new WaitForSeconds(0.001f);
        }
        paperRules.active = false;
        Debug.Log("Entra aqui tambien");
        paperRules.GetComponent<RectTransform>().localPosition = new Vector3(0,-1000,0);
        rulesButton.GetComponent<Button>().interactable = true;
        yield return null;
    }
    public void OnGameOverButtonClick(){
        SceneManager.LoadScene("initial_Scene");
    }
}
