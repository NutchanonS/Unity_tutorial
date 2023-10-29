using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class AttributesManager : MonoBehaviour
{
    public float health = 100f;
    //public float attack;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        //animator.SetTrigger("TakeDamage");
    }
    //public void DealDamage(GameObject target)
    //{
    //    var atm = target.GetComponent<EnemyAttributes>();
    //    if (atm != null)
    //    {
    //        //atm.TakeDamage(attack);
    //    }
    //}
}
