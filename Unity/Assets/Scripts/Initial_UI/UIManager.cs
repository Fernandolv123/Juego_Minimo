using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public List<Transform> spawners;
    public Canvas[] UI;
    void Start(){
        if (UI.Length != 0)
        ChangeCanvas(0);
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

    public void Exit(){
        Application.Quit();
    }
}
