using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartCheck : MonoBehaviour
{
    public string tagToCheck = "Player";
    public GameObject bossCamera;
    public Color gizmoColor = Color.white;

    private void Awake()
    {
        bossCamera.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag==tagToCheck)
        {
            TurnOnCamera();
        }
    }
    
    private void TurnOnCamera()
    {
        bossCamera.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, transform.localScale.y);
    }
}
