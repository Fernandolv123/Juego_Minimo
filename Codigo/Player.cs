using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public List<AudioClip> footsteps;
    
    private AudioSource audio;
    private Rigidbody rb;
    private bool moving = false;
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

        if (Input.GetKey(KeyCode.W) && canMove){
            //W go forward
            transform.position += Vector3.forward*speed * Time.deltaTime * position;
            moving=true;
            
        }else {
            moving=false;
        }

        if (Input.GetKeyDown(KeyCode.S) && canRotate){
            canMove = false;
            canRotate = false;
            //S turn around
            //transform.Rotate( 0, 1, 0 * Time.deltaTime );
            StartCoroutine("Turning");
            //playerPosition.Rotate(Vector3.down*-180,Space.World);
            position *= -1;
        }
    }

    IEnumerator Turning(){
        int time =0;
        while(time < 45){
        transform.Rotate( 0, 4, 0 * Time.deltaTime );
        time++;
        yield return new WaitForSeconds(0.01f);
        }
        canMove = true;
        canRotate=true;
    }

    IEnumerator Footsteps(){
        while(true){
            if (moving){
                audio.PlayOneShot(footsteps[Random.Range(0,footsteps.Count)]);
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }
}
