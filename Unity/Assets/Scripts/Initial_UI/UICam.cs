using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICam : MonoBehaviour
{
    public Image sprite;
    [Header("This contains variables related to camera movement")]
    [SerializeField]
    private Transform camTeleporter;

    public bool NewRound=> newRound;

    private bool newRound;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.right*2*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other){
        StartCoroutine("FadeOut");
        Debug.Log("Entra");
        
    }

    IEnumerator FadeOut(){
        yield return null;
        for (float i = 0; i <= 1f; i += Time.deltaTime)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, i);
            yield return null;
        }
        transform.position = camTeleporter.position;
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, i);
            yield return null;
        }
    }
}
