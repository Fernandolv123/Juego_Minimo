using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alucination : MonoBehaviour
{
    private Animator animator;
    private bool entered = false;
    private GameObject player;

    void Awake() {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
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
                player.GetComponent<Player>().StartCoroutine("Turning");
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                entered = true;
            }
        }

        if (other.gameObject.name=="ZombieKiller"){
            Destroy(gameObject);
        }
        
        if (other.gameObject.tag=="Player"){
            animator.SetBool("Attack",true);
            Debug.Log("Enter");
            GameManager.instance.die = true;
        }
    }
}
