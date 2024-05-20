using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

namespace Itens
{
    public class ItemLayout : MonoBehaviour
    {
        private ItemSetup currentSetup;
        public Image uiIcon;
        public TextMeshProUGUI uiValue;

      public void Load(ItemSetup setup)
        {
            currentSetup = setup;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiIcon.sprite = currentSetup.icon;
        }

        private void Update()
        {
            uiValue.text = currentSetup.soInt.value.ToString();
        }
    }
}
