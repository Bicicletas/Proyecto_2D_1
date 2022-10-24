using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string sceneName = "New Scene name here";

    public bool isAuto;

    public string uuid;

    private bool manualEnter;

    private bool canTp;

    private void Start()
    {
        canTp = false;
    }

    private void Update()
    {
        if(!isAuto && !manualEnter)
        {
            if (canTp)
            {
                manualEnter = Input.GetButtonDown("Fire1");
            }
        }
    }

    private void Teleprot(string objName)
    {
        if(objName == "Player")
        {
            canTp = true;
            if (isAuto || (!isAuto && manualEnter))
            {
                FindObjectOfType<PlayerController>().nextUuid = uuid;
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Teleprot(other.name);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Teleprot(other.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTp = false;
    }
}
