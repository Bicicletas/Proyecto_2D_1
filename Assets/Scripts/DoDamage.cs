using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    //public float timeToRevivePlayer;
    //private float timeRevivalCounter;
    //private bool isPlayerReviving;
    //private GameObject player;
    
    public int damage = 10;
    /*
    private void Update()
    {
        if (isPlayerReviving)
        {
            timeRevivalCounter -= Time.deltaTime;
            if (timeRevivalCounter <= 0)
            {
                isPlayerReviving = false;
                player.SetActive(true);
            }
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            /*
            player = other.gameObject;
            player.SetActive(false);
            isPlayerReviving = true;
            timeRevivalCounter = timeToRevivePlayer;
            */
            StartCoroutine(SafeTime(other.gameObject));

            if (!this.isActiveAndEnabled)
            {
                StopAllCoroutines();
                print("caca");
            }

            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
        }
    }

    IEnumerator SafeTime(GameObject g)
    {
        g.GetComponent<BoxCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(1f);
        g.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
