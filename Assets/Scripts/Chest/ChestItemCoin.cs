using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Itens;

public class ChestItemCoin : ChestItemBase
{
    public int coinNumber = 5;
    public GameObject coinObject;
    private List<GameObject> itens = new List<GameObject>();
    public float tweenEndTime;

    public override void ShowItem()
    {
        base.ShowItem();
        CreateItem();
    }

    private void CreateItem()
    {
        for(int i=0;i<coinNumber;i++)
        {
            var item=Instantiate(coinObject);
            item.transform.position = transform.position+Vector3.forward*Random.Range(-5f,5f)+Vector3.right*Random.Range(-5f,5f);
            item.transform.DOScale(0, 0.5f).SetEase(Ease.OutBack).From();
            itens.Add(item);
            
        }
    }

    public override void Collect()
    {
        base.Collect();
        foreach(var i in itens)
        {
            i.transform.DOMoveY(2f, tweenEndTime).SetRelative();
            i.transform.DOScale(0,tweenEndTime/2).SetDelay(tweenEndTime/2);
            ItemManager.Instance.AddByType(ItemType.COIN);

        }
    }
}
