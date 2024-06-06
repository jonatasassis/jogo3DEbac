using Animation;
using Cloth;
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
    public float damageMultiply = 1f;

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

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }

        public void Damage(float f)
    {
      
        
        currentLife -= f*damageMultiply;

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

    public void ChangeDamageMultiply(float damage, float duration)
    {
        StartCoroutine(ChangeDamageMultiplyCoroutine(damageMultiply, duration));
    }

    IEnumerator ChangeDamageMultiplyCoroutine(float damageMultiply, float duration)
    {
        this.damageMultiply = damageMultiply;
        yield return new WaitForSeconds(duration);
        this.damageMultiply = 1;

    }
}
