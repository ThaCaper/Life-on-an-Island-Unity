using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterBehavior : MonoBehaviour
{
    public GameObject weaponIsOn;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int randomAtk = Random.Range(1, 2);
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("Speed", 2.0f);
        }
        else
        {
            anim.SetFloat("Speed", 1.0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            anim.SetInteger("RandomAttack", randomAtk);
        }
    }
}
