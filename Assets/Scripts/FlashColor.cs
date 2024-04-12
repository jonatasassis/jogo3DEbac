using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Color damageColor,defaultColor;
    public float flashDuration = 0.1f;
    public int flashCount;
    private Tween currentTween;
    private void Start()
    {
        defaultColor = meshRenderer.material.GetColor("_Color");
    }

    [NaughtyAttributes.Button]
    public void Flash()
    {
        if (!currentTween.IsActive())
        {
            currentTween = meshRenderer.material.DOColor(damageColor, "_Color", flashDuration).SetLoops(flashCount, LoopType.Yoyo);
        }
    }
}
