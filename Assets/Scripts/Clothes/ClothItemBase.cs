using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth
{
    public class ClothItemBase : MonoBehaviour
    {
        public ClothType clothType;
        public string compareTag = "Player";
        public float duration;

        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }

        public virtual void Collect()
        {
            var setup= ClothManager.Instance.GetSetupByType(clothType);
            Player.Instance.ChangeTexture(setup,duration);
            HideObjects();
        }

        private void HideObjects()
        {
            gameObject.SetActive(false);
        }
    }
}
