using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public float verticalSpeed = 1f;
    public float scaleFactor = 5f;
    public float alphaFactor = 0.5f;
    public float damagePoints;

    public TextMeshProUGUI damageText;

    private void Start()
    {
        damageText.text = damagePoints.ToString();
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + verticalSpeed * Time.deltaTime, 0);
        transform.localScale *= 1 - Time.deltaTime / scaleFactor;
        damageText.alpha -= alphaFactor * Time.deltaTime;
    }
}
