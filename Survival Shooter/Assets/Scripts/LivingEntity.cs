using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float health_Max = 100f;
    public float health { get; protected set; }
    public bool dead { get; protected set; }
    public event Action onDeath;

    protected virtual void OnEnable()
    {
        dead = false;
        health = health_Max;
    }

    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        health -= damage;

<<<<<<< HEAD
        if (health <= 0 && !dead)
=======
        if(health <= 0 && !dead)
>>>>>>> a106ad60b49962e8b463a28d0541103af20a3324
        {
            Die();
        }
    }

    public virtual void Die()
    {
<<<<<<< HEAD
        if (onDeath != null)
=======
        if(onDeath != null)
>>>>>>> a106ad60b49962e8b463a28d0541103af20a3324
        {
            onDeath();
        }
        dead = true;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> a106ad60b49962e8b463a28d0541103af20a3324
