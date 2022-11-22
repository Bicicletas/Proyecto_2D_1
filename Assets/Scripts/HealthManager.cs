using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public int expWhenDefeated;

    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    private bool isBlinkinng;

    [SerializeField] private float blinkingDuration;
    private float blinkingCounter;

    private SpriteRenderer _characterRenderer;

    private void Start()
    {
        _characterRenderer = GetComponent<SpriteRenderer>();
        UpdateMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (isBlinkinng)
        {
            blinkingCounter -= Time.deltaTime;

            if(blinkingCounter > blinkingDuration * 0.8)
            {
                ToggleColor(false);
            }
            else if (blinkingCounter > blinkingDuration * 0.6)
            {
                ToggleColor(true);
            }
            else if (blinkingCounter > blinkingDuration * 0.4)
            {
                ToggleColor(false);
            }
            else if (blinkingCounter > blinkingDuration * 0.2)
            {
                ToggleColor(true);
            }
            else if (blinkingCounter > 0)
            {
                ToggleColor(false);
            }
            else
            {
                ToggleColor(true);
                isBlinkinng = false;

                if (gameObject.name == "Player")
                {
                    //GetComponent<BoxCollider2D>().enabled = true;
                    //GetComponent<PlayerController>().canMove = true;
                }
            }
        }
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (gameObject.tag.Equals("Enemy"))
            {
                GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(expWhenDefeated * GameObject.Find("Player").GetComponent<CharacterStats>().level);
            }
            gameObject.SetActive(false);
        }

        if(blinkingDuration > 0)
        {
            isBlinkinng = true;
            blinkingCounter = blinkingDuration;
            if (gameObject.name == "Player")
            {
                StartCoroutine(SafeTime());
                //GetComponent<BoxCollider2D>().enabled = false;
                //GetComponent<PlayerController>().canMove = false;
            }
        }
    }
    IEnumerator SafeTime()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(1f);
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    private void ToggleColor(bool isVisible)
    {
        Color color = _characterRenderer.color;
        color = new Color(color.r, color.g, color.b, isVisible ? 1 : 0);
        _characterRenderer.color = color;
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }
}
