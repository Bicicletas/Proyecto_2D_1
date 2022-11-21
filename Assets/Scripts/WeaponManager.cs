using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int activeWeapon;

    private List<GameObject> weaponList = new List<GameObject>();

    private void Start()
    {
        foreach (Transform w in transform)
        {
            weaponList.Add(w.gameObject);
        }

        for (int i = 0; i < weaponList.Count; i++)
        {
            weaponList[i].SetActive(i == activeWeapon);
        }
    }

    public void ChangeWeapon(int newWeapon)
    {
        weaponList[activeWeapon].SetActive(false);
        activeWeapon = newWeapon;
        weaponList[activeWeapon].SetActive(true);
    }

    public List<GameObject> GetAllWeapons()
    {
        return weaponList;
    }
}
