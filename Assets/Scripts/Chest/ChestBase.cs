using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public Animator animator;
    public string triggerOpen = "open";

    [Header ("notification")]
    public GameObject notification;
    public float tweenDuration=0.5f;
    public Ease tweenEase=Ease.OutBack;
    private float startScale;
    // Start is called before the first frame update
    void Start()
    {
        HideNotification();
        startScale=notification.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [NaughtyAttributes.Button]
    private void OpenChest()
    {
        animator.SetTrigger(triggerOpen);
    }

    public void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();
        if (p != null) 
        {
            ShowNotification();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();
        if (p != null)
        {
            HideNotification();
        }

    }
    [NaughtyAttributes.Button]
    private void ShowNotification()
    {
        notification.SetActive(true);
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(startScale,tweenDuration);
    }

    [NaughtyAttributes.Button]
    private void HideNotification()
    {
        notification.SetActive(false);
    }

}
