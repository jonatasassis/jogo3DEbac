using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GunBase : MonoBehaviour
{
    public ProjectilBase prefabProjectil;
    public Transform posInicialTiro;
    public float delayTiro;
    public Coroutine coroutineAtual;
    public KeyCode teclaTiro;
    public float speed ;

    public virtual void Atirar()
    {
        var projectil = Instantiate(prefabProjectil);
        projectil.transform.position= posInicialTiro.position;
        projectil.transform.rotation= posInicialTiro.rotation;
        projectil.velProjectil = speed;

        

    }

   protected virtual IEnumerator DelayAtirar()
    {
        while (true)
        {
            Atirar();
            yield return new WaitForSeconds(delayTiro);
        }
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
