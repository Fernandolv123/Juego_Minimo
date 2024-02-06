using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant_Rotate : MonoBehaviour
{
    private bool rotate = false;
    private Quaternion lookrotation;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate){
            Vector3 player = new Vector3(GameManager.instance.playerPrefab.transform.position.x,GameManager.instance.playerPrefab.transform.position.y,GameManager.instance.playerPrefab.transform.position.z+1);
            direction = (player - transform.position).normalized;
            lookrotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation,lookrotation,Time.deltaTime*2);
        }
    }

    public void LookAtPlayer(bool set) {
        rotate = set;
    }
}
