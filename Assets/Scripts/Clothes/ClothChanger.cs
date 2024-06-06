using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothChanger : MonoBehaviour
{
    public Material playerMaterial;
    public Color playerColor,defaultColor;
    public string shaderName = "_Color";
  

    private void Start()
    {
        playerMaterial.GetColor(shaderName);
        playerMaterial.SetColor(shaderName, defaultColor);
    }
    [NaughtyAttributes.Button]
  private void ChangeTexture()
    {
       
           playerMaterial.SetColor(shaderName, playerColor);
        
    }
}
