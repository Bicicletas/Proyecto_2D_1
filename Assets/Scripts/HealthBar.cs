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
    }

    private void Update()
    {
        healthBarSlider.maxValue = player.GetComponent<HealthManager>().maxHealth;

        healthBarSlider.value = player.GetComponent<HealthManager>().CurrentHealth;
    }
}
