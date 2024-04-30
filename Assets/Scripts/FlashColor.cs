using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    [Header ("Setup")]
    public Color damageColor;
    public float flashDuration = 0.1f;
    public int flashCount;
    private Tween currentTween;

    private void OnValidate()
    {
        if (meshRenderer != null) 
        {
            meshRenderer=GetComponent<MeshRenderer>();
        }

       
        if (skinnedMeshRenderer == null)
        {
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        }
        
    }
   

    [NaughtyAttributes.Button]
    public void Flash()
    {

        if(meshRenderer !=null && !currentTween.IsActive())
        {
            currentTween = meshRenderer.material.DOColor(damageColor, "_Color", flashDuration).SetLoops(flashCount, LoopType.Yoyo);
        }
       
        if (skinnedMeshRenderer != null && !currentTween.IsActive())
        {
            currentTween = skinnedMeshRenderer.material.DOColor(damageColor, "_Color", flashDuration).SetLoops(flashCount, LoopType.Yoyo);
        }
        
    }
}
