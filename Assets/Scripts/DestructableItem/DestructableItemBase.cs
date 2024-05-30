using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableItemBase : MonoBehaviour
{
    public HealthBase healthBase;
    public float shakeDuration = .1f;
    public int shakeForce=1;
    public int dropCoinsAmount = 10;
    public GameObject coinPrefab;
    public Transform dropPosition;

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
        DropCoin();
    }

    private void DropCoin()
    {
        var i = Instantiate(coinPrefab);
        i.transform.position = dropPosition.position;
        i.transform.DOScale(0, 1f).SetEase(Ease.OutBack).From();
    }
}
