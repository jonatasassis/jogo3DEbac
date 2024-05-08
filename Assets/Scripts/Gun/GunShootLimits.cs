using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class GunShootLimits : GunBase
{
    public List<UIFillUpdater> uiGunUpdateList;
    public float maxShoots=5;
    public float timeToRecharge=1;
    private float currentShoots;
    private bool recharging=false;

    private void Awake()
    {
        GetAllUIs();
        //
    }
    protected override IEnumerator DelayAtirar()
    {
        if (recharging)
        {
            yield break;
            
        }
        while(true)
        {
            if (currentShoots < maxShoots)
            {
                Atirar();
                currentShoots++;
                CheckRecharge();
                UpdateUI();
                yield return new WaitForSeconds(delayTiro);
            }


        }
    }

    private void CheckRecharge()
    {
        if (currentShoots >= maxShoots)
        {
            StopShoot();
            StartRecharge();
        }
    }

    private void StartRecharge()
    {
        recharging = true;
        StartCoroutine(RechargeCorountine());
    }

    IEnumerator RechargeCorountine()
    {
        float time = 0;
        while (time<timeToRecharge)
        {
            time += Time.deltaTime;
            uiGunUpdateList.ForEach(i => i.UpdateValue(time/timeToRecharge));
            yield return new WaitForEndOfFrame();
        }
        currentShoots= 0;
        recharging = false;
    }


    private void UpdateUI()
    {
        uiGunUpdateList.ForEach(i=> i.UpdateValue(maxShoots,currentShoots));
    }

    private void GetAllUIs()
    {
        uiGunUpdateList = GameObject.FindObjectsOfType<UIFillUpdater>().ToList();
    }
}
