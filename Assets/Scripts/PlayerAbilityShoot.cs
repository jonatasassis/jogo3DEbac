using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    
    public GunBase Arma;
    protected override void Init()
    {
        base.Init();
        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => StopShoot();
    }

   

    private void StartShoot()
    {

        Arma.StartShoot();
        Debug.Log("Atirar");
    }
    private void StopShoot()
    {
        Arma.StopShoot();
        Debug.Log("Parar de Atirar");
    }

}
