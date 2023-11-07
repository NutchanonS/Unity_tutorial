using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(SphereCollider))]
//[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    public SpellScriptableObject spellToCast;

    private SphereCollider myCollider;
    private Rigidbody myRigidbody;

    private void Awake()
    {
        if (spellToCast.spelltype == "projectile") { 

            myCollider = GetComponent<SphereCollider>();
            myCollider.isTrigger = true;
            myCollider.radius = spellToCast.SpellRadius;

            myRigidbody = GetComponent<Rigidbody>();
            myRigidbody.isKinematic = true;

        }
        Destroy(this.gameObject, spellToCast.Lifetime);
    }
    // Update is called once per frame
    void Update()
    {
        if (spellToCast.spelltype == "projectile")
        {
            if (spellToCast.speed > 0) 
            { 
                transform.Translate(Vector3.forward * spellToCast.speed * Time.deltaTime);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        // Apply spell (effects, particle, sound) to whatever we hit.
        if (other.transform.CompareTag("Enemy"))
        {
            EnemyInteract target = other.transform.GetComponent<EnemyInteract>();
            //if (target.interactionType == InteractableType.Enemy)
            //{
            //    target.GetComponent<AttributesManager>().TakeDamage(spellToCast.DamageAmount);
            //}
            target.GetComponent<AttributesManager>().TakeDamage(spellToCast.DamageAmount);
            Destroy(this.gameObject);
        }
    }
}
