using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cloth;

namespace Cloth
{
    public class ClothChanger : MonoBehaviour
    {
        public Material playerMaterial;
        public Color playerColor, defaultColor;
        public string shaderName = "_Color";


        private void Awake()
        {
            playerMaterial.GetColor(shaderName);
            playerMaterial.SetColor(shaderName, defaultColor);
        }
        [NaughtyAttributes.Button]
        private void ChangeTexture()
        {

            playerMaterial.SetColor(shaderName, playerColor);

        }

        public void ChangeTexture(ClothSetup setup)
        {

            playerMaterial.SetColor(shaderName,setup.playerColor);

        }
        public void ResetTexture(ClothSetup setup)
        {

            playerMaterial.SetColor(shaderName, defaultColor);

        }

    }
}
