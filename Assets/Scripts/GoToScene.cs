using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string sceneName = "New Scene name here";

    public bool isAuto;

    private bool manualEnter;

    public bool canTp;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if (isAuto)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            canTp = true;
            if (!isAuto && manualEnter)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canTp = false;
    }
}
