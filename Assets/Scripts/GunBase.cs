using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GunBase : MonoBehaviour
{
    public ProjectilBase prefabProjectil;
    public Transform posInicialTiro;
    public float delayTiro;
    public Coroutine coroutineAtual;
    public KeyCode teclaTiro;
    public GameObject projectil;

    // Update is called once per frame
   

    public void Atirar()
    {
        Instantiate(prefabProjectil);
        projectil.transform.position= posInicialTiro.position;
        projectil.transform.rotation= posInicialTiro.rotation;

    }

    IEnumerator DelayAtirar()
    {
       
            Atirar();
            yield return new WaitForSeconds(delayTiro);
        
    }

    public void StartShoot()
    {
        StopShoot();
        coroutineAtual = StartCoroutine(DelayAtirar());
    }

    public void StopShoot()
    {
        if (coroutineAtual != null)
        {
            StopCoroutine(coroutineAtual);

        }
    }
}
