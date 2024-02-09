using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public List<AudioClip> footsteps;
    public GameObject camera;
    public Image redImage;
    public Text gameOverText;
    
    private AudioSource audio;
    private Rigidbody rb;
    private bool moving = false;
    private bool running =false;
    private bool croaching = false;
    private int position = 1;
    private bool canMove = true;
    private bool canRotate=true;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine("Footsteps");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.die){

        
        if (Input.GetKeyDown(KeyCode.LeftControl)){
            StartCoroutine("Croaching",new Vector3(1,0.5f,1));
            croaching = true;
        } 

        if (Input.GetKeyUp(KeyCode.LeftControl)){
            StartCoroutine("Croaching",new Vector3(1,1f,1));
            croaching = false;
        }

        if (Input.GetKey(KeyCode.W) && canMove){
            //W go forward
            if (croaching){
                transform.position += Vector3.forward*(speed/2) * Time.deltaTime * position;
            } else if (Input.GetKey(KeyCode.LeftShift)){
                transform.position += Vector3.forward*(speed*2) * Time.deltaTime * position;
                running = true;
                moving=true;
                return;
            }else {
                transform.position += Vector3.forward*speed * Time.deltaTime * position;
            }
            moving=true;
            
        }else {
            running = false;
            moving=false;
        }

        if (Input.GetKeyDown(KeyCode.S) && canRotate){
            canMove = false;
            canRotate = false;
            StartCoroutine("Turning");
            position *= -1;
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            //Pestañeo
        }
        }
    }

    IEnumerator Turning(){
        int time =0;
        while(time < 45){
        transform.Rotate( 0, 4, 0 * Time.deltaTime);
        time++;
        yield return new WaitForSeconds(0.01f);
        }
        canMove = true;
        canRotate=true;
    }


    public IEnumerator Croaching(Vector3 setslace){
    float counter = 0;
    Vector3 startscale = transform.localScale;
    while (counter < 0.5)
    {
        counter += Time.deltaTime;
        transform.localScale = Vector3.Lerp(startscale, setslace, counter / 0.5f);
        yield return null;
    }
    }

    IEnumerator Footsteps(){
        while(true){
            if (moving && !croaching){
                if (running){
                    audio.PlayOneShot(footsteps[Random.Range(0,footsteps.Count)]);
                    GameManager.instance.PlayerChangeState(running,moving);
                    yield return new WaitForSeconds(0.5f);
                } else {
                    audio.PlayOneShot(footsteps[Random.Range(0,footsteps.Count)]);
                    GameManager.instance.PlayerChangeState(running,moving);
                    yield return new WaitForSeconds(1f);
                }
            }
            GameManager.instance.PlayerChangeState(false,false);
            yield return null;
        }
    }

    public void ResetPosition(){
        position = 1;
    }

    public void Die(){
        if (!camera.GetComponent<Animator>().enabled){
            camera.GetComponent<Animator>().enabled = true;
            StartCoroutine("FadeIn");
            Invoke("SpawnText",1f);
        }
        //cambiar el alpha hijo de la camara para hacer un fade a rojo
    }
    public void SpawnText(){
        gameOverText.enabled = true;
        StartCoroutine("BiggerText");

        //StopCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        redImage.enabled = true;
        for (float i = 0; i <= 1f; i += Time.deltaTime/3f)
        {
            if (i < 1){
                redImage.color = new Color(redImage.color.r, redImage.color.g, redImage.color.b, i);
            }
            yield return null;
        }
    }

    IEnumerator BiggerText() {
        for (int i = 0; i <100; i+=1 ){
            gameOverText.fontSize = i;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
