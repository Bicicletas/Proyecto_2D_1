using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    public GameObject obstalces;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            obstalces.SetActive(false);
        }
    }
}
