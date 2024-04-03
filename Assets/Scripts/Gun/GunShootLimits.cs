using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunShootLimits : GunBase
{
    public float maxShoots=5;
    public float timeToRecharge=1;
    private float currentShoots;
    private bool recharging=false;

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
            yield return new WaitForEndOfFrame();
        }
        currentShoots= 0;
        recharging = false;
    }
}
