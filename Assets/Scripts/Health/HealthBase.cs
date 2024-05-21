using Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HealthBase : MonoBehaviour,IDamageable
{
    [SerializeField]private float currentLife;
    public float startLife;
    public float delayToDestroy = 3f;
    public Action<HealthBase> onDamage;
    public Action <HealthBase>onKill;
    public bool destroyOnKill=false;
    public List <UIFillUpdater> UIGunUpdate;

    public void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }

    private void UpdateUI()
    {
        if(UIGunUpdate!=null)
        {
            UIGunUpdate.ForEach(i=>i.UpdateValue((float)currentLife/startLife));
        }
    }

    public void ResetLife()
    {
        currentLife = startLife;
        UpdateUI();
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
        UpdateUI();
        onDamage?.Invoke(this);
    }

    public void Damage(float damageAmount, Vector3 dir)
    {
        Damage(damageAmount);
    }
}
