using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]
public class SpellScriptableObject : ScriptableObject
{
    public float DamageAmount = 10f;
    public float ManaCost = 5f;
    public float Lifetime = 2f;
    public float speed = 15f;
    public float SpellRadius = 0.5f;

    // Status effect
    //Thumbnail
    //Time between casts
    //Magic elements;
}
