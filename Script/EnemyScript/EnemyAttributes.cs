using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public int health;
    public int attack;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.Log("animator=Null....");
        }
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        animator.SetTrigger("TakeDamage");
    }
    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            atm.TakeDamage(attack);
        }
    }
}
