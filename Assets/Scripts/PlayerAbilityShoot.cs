using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    
    public GunBase Arma;
    private GunBase currentGun;
    public Transform gunPosition;
    protected override void Init()
    {
        base.Init();
        CreateGun();
        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => StopShoot();
    }

    private void CreateGun()
    {
        currentGun = Instantiate(Arma, gunPosition);
        currentGun.transform.localPosition = currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void StartShoot()
    {

        currentGun.StartShoot();
        Debug.Log("Atirar");
    }
    private void StopShoot()
    {
        currentGun.StopShoot();
        Debug.Log("Parar de Atirar");
    }

}
