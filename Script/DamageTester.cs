using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{

    // Update is called once per frame
    public AttributesManager playerAtm;
    public EnemyAttributes enemyAtm;
    private void Update()
    {
        //player attack enemy
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerAtm.DealDamage(enemyAtm.gameObject);
        }
        //enemy attack player
        if (Input.GetKeyDown(KeyCode.G))
        {
            enemyAtm.DealDamage(playerAtm.gameObject);
        }
    }
}
