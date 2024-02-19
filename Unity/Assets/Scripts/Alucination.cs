using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alucination : MonoBehaviour
{
    private Animator animator;
    private bool entered = false;
    private GameObject player;
    private AudioSource audio;
    private AudioSource zombieAudio;
    public AudioClip audioZombieStop;
    private Image fadeOutImage;

    void Awake() {
        zombieAudio = GetComponent<AudioSource>();
        fadeOutImage = GameObject.FindGameObjectWithTag("FadeInImage").GetComponent<Image>();
        audio = GameObject.FindGameObjectWithTag("SoundController").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("Die",11f);
    }
    public void Die(){
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "BackCollider"){
            Debug.Log(other+"||"+player);
            if (!entered){
                GameManager.instance.aboutToDie=true;
                player.GetComponent<Player>().StartCoroutine("Turning");
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                entered = true;
            }
        }

        if (other.gameObject.name=="ZombieKiller"){
            audio.PlayOneShot(audioZombieStop);
            StartCoroutine("FadeIn");
            gameObject.transform.position = new Vector3(-1000,1000,1000);
        }
        
        if (other.gameObject.tag=="Player"){
            animator.SetBool("Attack",true);
            Debug.Log("Enter");
            GameManager.instance.die = true;
            zombieAudio.Stop();
        }
    }

    IEnumerator FadeIn(){
        Debug.Log("{FadeIn} Entra");
        fadeOutImage.enabled = true;
        for (float i = 1; i >= 0; i -= Time.deltaTime*2)
        {
            fadeOutImage.color = new Color(fadeOutImage.color.r, fadeOutImage.color.g, fadeOutImage.color.b, i);
            yield return null;
        }
        fadeOutImage.enabled = false;
        Destroy(gameObject);
        yield return null; 
        
    }
}
