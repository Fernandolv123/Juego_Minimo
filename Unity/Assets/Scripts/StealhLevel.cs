using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealhLevel : Level
{
    //ponemos un tiempo en el que no moriremos
    private float timer;
    private bool spawned = false;

    public GameObject mutantPrefab;
    public GameObject mutantSpawner;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (base.IsActive()){
            if(true){
                //Tenemos que poner algun tiempo de margen para no morir instantaneamente
                if (GameManager.instance.PlayerWalking()){
                    if (!spawned) {
                        spawned = true;
                        Instantiate(mutantPrefab,mutantSpawner.transform.position,mutantSpawner.transform.rotation);
                    }
                    Debug.Log("Moriste");
                }
            }
        }
    }
}
