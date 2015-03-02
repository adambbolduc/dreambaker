﻿using UnityEngine;
using System.Collections;

public class PlayerAttackBehaviour : MonoBehaviour {

    public float attackDamage = 1;

    void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Fire2") && other.CompareTag("Mob"))
        {
            Debug.Log("Attaque");
            other.SendMessage("takeDamage", attackDamage);
            other.GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
        }
    }
}
