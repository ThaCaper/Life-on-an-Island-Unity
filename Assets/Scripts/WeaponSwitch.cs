﻿using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int currentWeapon = 0;
    public int maxWeapons = 2;
    public Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        SelectWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon + 1 <= maxWeapons)
            {
                currentWeapon++;
            }
            else
            {
                currentWeapon = 0;
            }

            SelectWeapon(currentWeapon);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon - 1 >= maxWeapons)
            {
                currentWeapon--;
            }
            else
            {
                currentWeapon = maxWeapons;
            }
            SelectWeapon(currentWeapon);
        }

        if (currentWeapon == maxWeapons + 1)
        {
            currentWeapon = 0;
        }

        if (currentWeapon == maxWeapons - 1)
        {
            currentWeapon = maxWeapons;
        }

    }

    private void SelectWeapon(int currentWeapon)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == currentWeapon)
            {
                if (transform.GetChild(i).name == "Fists")
                {
                    anim.SetBool("WeaponIsOn", false);
                }
                else
                {
                    anim.SetBool("WeaponIsOn", true);
                }
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
