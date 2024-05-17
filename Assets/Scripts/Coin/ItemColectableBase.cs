using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem ParticleSystem;
    public float timeToHide=3;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if(graphicItem!=null)
        {
            graphicItem.SetActive(false);
        }

        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    private void HideObjects()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect() 
    {
        if(ParticleSystem!=null)
        {
            ParticleSystem.Play();
        }

        if(audioSource!=null)
        {
            audioSource.Play();
        }
    }
    
}
