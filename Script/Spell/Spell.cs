using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    public SpellScriptableObject spellToCast;

    private SphereCollider myCollider;
    private Rigidbody myRigidbody;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = spellToCast.SpellRadius;

        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        Destroy(this.gameObject, spellToCast.Lifetime);
    }
    // Update is called once per frame
    void Update()
    {
        if (spellToCast.speed > 0) 
        { 
            transform.Translate(Vector3.forward * spellToCast.speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Apply spell (effects, particle, sound) to whatever we hit.
        if (other.transform.CompareTag("Enemy"))
        {
            Interactable target = other.transform.GetComponent<Interactable>();
            if (target.interactionType == InteractableType.Enemy)
            {
                target.GetComponent<AttributesManager>().TakeDamage(spellToCast.DamageAmount);
            }
            Destroy(this.gameObject);
        }
    }
}
