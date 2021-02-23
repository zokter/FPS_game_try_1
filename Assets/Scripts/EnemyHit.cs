using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public float health = 50f;

    //the function receives damage from the weapon script as input
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            fknDie(); 
        }
    }

    public void fknDie()
    {
        Destroy(gameObject);
    }
}
