using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damage;

    public GameObject bloodParticle;
    public GameObject damageDamageCanvas;

    private GameObject hitPoint;

    private void Start()
    {
        hitPoint = transform.Find("HitPoint").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject canvas = Instantiate(damageDamageCanvas, hitPoint.transform.position, Quaternion.identity);
            canvas.GetComponent<DamageNumber>().damagePoints = damage;

            other.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
            if(bloodParticle != null && hitPoint != null)
            {
                Instantiate(bloodParticle, hitPoint.transform.position, transform.rotation);
            }
        }
    }
}
