using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Canvas[] UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string scene){
        SceneManager.LoadScene(scene);
    }

    public void ChangeCanvas(int number){
        foreach(Canvas canvas in UI){
            canvas.enabled = false;
        }
        UI[number].enabled = true;
    }
}
