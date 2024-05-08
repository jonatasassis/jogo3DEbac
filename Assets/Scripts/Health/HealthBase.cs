using Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HealthBase : MonoBehaviour,IDamageable
{
    private float currentLife;
    public float startLife;
    public float delayToDestroy = 3f;
    public Action<HealthBase> onDamage;
    public Action <HealthBase>onKill;
    public bool destroyOnKill=false;

    public void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }
    protected void ResetLife()
    {
        currentLife = startLife;
    }

    protected virtual void Kill()
    {
        if (destroyOnKill)
        {
            Destroy(gameObject, delayToDestroy);
        }

        onKill?.Invoke(this);
    }

   
    public void Damage(float f)
    {
      
        
        currentLife -= f;

        if (currentLife <= 0)
        {
            Kill();
        }
        onDamage?.Invoke(this);
    }

    public void Damage(float damageAmount, Vector3 dir)
    {
        Damage(damageAmount);
    }
}
