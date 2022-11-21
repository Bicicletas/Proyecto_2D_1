using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    public int level;
    public int exp;
    public int[] expToLevelUp;
    public int[] maxHealthLevels;

    public TextMeshProUGUI levelText;

    private HealthManager _healthManager;

    private void Start()
    {
        _healthManager = GetComponent<HealthManager>();
        AddExperience(0);
        levelText.text = "" + level;
    }

    public void AddExperience(int expToAdd)
    {
        exp += expToAdd;

        if (level >= expToLevelUp.Length)
        {
            return;
        }
        if (exp >= expToLevelUp[level])
        {
            level++;
            exp -= expToLevelUp[level - 1];
            _healthManager.UpdateMaxHealth(maxHealthLevels[level]);
            levelText.text = "" + level;
        }
    }
}
