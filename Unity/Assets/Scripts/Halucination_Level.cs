using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halucination_Level : Level
{
    public GameObject spriteHalucination;
    public GameObject playerPrefab;
    public GameObject frontCanavas;
    public GameObject backCanvas;

    private bool canvasImageActive;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine("CanvasImageSelector");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (base.IsActive()) {
            frontCanavas.GetComponent<RectTransform>().position = new Vector3(playerPrefab.transform.position.x,playerPrefab.transform.position.y, playerPrefab.transform.position.z+5);
            backCanvas.GetComponent<RectTransform>().position = new Vector3(playerPrefab.transform.position.x, playerPrefab.transform.position.y, playerPrefab.transform.position.z - 5);
            //frontCanavas.GetComponent<RectTransform>().position.z = playerPrefab.transform.position.z+5;
        }
    }

    IEnumerator CanvasImageSelector() {
        while (true) {
            yield return null;
            if (base.IsActive()) {
                if (!canvasImageActive)
                {
                    int random = Random.Range(0, 2);
                    if (random == 2) {
                        //spawnear aqui
                    }
                }
            }

        }


    }
}
