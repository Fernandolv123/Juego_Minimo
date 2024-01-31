using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silent_Level : Level
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        //base.Update();
        if (base.IsActive()){
            GameManager.instance.ManagerAudioSource().Pause();
            
        }
    }
}
