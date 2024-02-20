using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_script : MonoBehaviour
{
    private int speed;
    private bool stop;
    public float dir;
    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        speed = 4;
        if (dir == 0){
            dir = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop){
            transform.Translate(-Vector3.forward * speed *Time.deltaTime*dir,Space.World);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag=="Player"){
            stop = true;
        }
    }
}
