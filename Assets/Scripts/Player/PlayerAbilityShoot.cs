using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<UIGunUpdate> uiGunUpdateList;
    
    public GunBase arma1,arma2;
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
        
        currentGun = Instantiate(arma1, gunPosition);
        currentGun.transform.localPosition = currentGun.transform.localEulerAngles = Vector3.zero;
       
    }

    private void Update()
    {
        SelectGun();
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

    private void SelectGun()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
             DestroyGun();
            currentGun = Instantiate(arma1, gunPosition);
            currentGun.transform.localPosition = currentGun.transform.localEulerAngles = Vector3.zero;


        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {


            DestroyGun();
            currentGun = Instantiate(arma2, gunPosition);
            currentGun.transform.localPosition = currentGun.transform.localEulerAngles = Vector3.zero;


        }
    }

    private void DestroyGun()
    {
        Destroy(currentGun.gameObject);
    }
}
