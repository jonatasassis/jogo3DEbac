using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableItemBase : MonoBehaviour
{
    public HealthBase healthBase;

    private void OnValidate()
    {
        if(healthBase==null)
        {
            healthBase = GetComponent<HealthBase>();
        }
    }
    private void Awake()
    {
        OnValidate();
        healthBase.onDamage += OnDamage;
    }

    
    private void OnDamage(HealthBase h)
    {
        transform.DOShakeScale(.5f,Vector3.up,5);
    }
}
