using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilBase : MonoBehaviour
{
    public float delayDestruirPorjectil;
    public int qtdDano;
    public float velProjectil;


    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject,delayDestruirPorjectil);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward *velProjectil* Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageable = collision.transform.GetComponent<IDamageable>();

        if (damageable!=null)
        {
            damageable.Damage(qtdDano);
            
        }

        Destroy(gameObject);
    }
}
