using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public KeyCode keycode = KeyCode.B;
    public Animator animator;
    public string triggerOpen = "open";
    public ChestItemBase chestItemBase;

    [Header ("notification")]
    public GameObject notification;
    public float tweenDuration=0.5f;
    public Ease tweenEase=Ease.OutBack;
    private float startScale;
    private bool chestOpened=false;
    // Start is called before the first frame update
    void Start()
    {
        HideNotification();
        startScale=notification.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keycode)&& notification.activeSelf)
        {
            OpenChest();
        }
        
    }

    [NaughtyAttributes.Button]
    private void OpenChest()
    {
        if (chestOpened) return;
        animator.SetTrigger(triggerOpen);
        chestOpened = true;
        HideNotification();
        Invoke(nameof(ShowItem), 2f);
    }

    private void ShowItem()
    {
        chestItemBase.ShowItem();
        Invoke(nameof(CollectItem), 1f);
    }

    private void CollectItem()
    {
        chestItemBase.Collect();
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
