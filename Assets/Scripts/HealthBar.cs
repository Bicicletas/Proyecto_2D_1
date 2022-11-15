using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBarSlider;

    public GameObject player;

    private void Start()
    {
        healthBarSlider = GetComponent<Slider>();

        healthBarSlider.maxValue = player.GetComponent<HealthManager>().maxHealth;
    }

    private void Update()
    {
        healthBarSlider.value = player.GetComponent<HealthManager>().CurrentHealth;
    }
}
