using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Scripts.Singleton;
using UnityEditor.PackageManager.Requests;

namespace Itens
{
    public enum ItemType
    {
        COIN,
        LIFE_PACK
    }

    public class ItemManager : Singleton<ItemManager>
    {
        
        public TextMeshProUGUI uiTextCoins;
        public List<ItemSetup> itemSetups;

        // Start is called before the first frame update
        void Start()
        {
            Reset();
        }

        private void Reset()
        {
           foreach(var i in itemSetups)
            {
                i.soInt.value = 0;
            }
           
        }

        public void AddByType(ItemType itemType, int amount = 1)
        {
            if(amount < 0)
            {
                return;
            }
            itemSetups.Find(i => i.itemType == itemType).soInt.value+=amount;
            

        }
        public void RemoveByType(ItemType itemType, int amount = -1)
        {
            if (amount >0)
            {
                return;
            }
            var item= itemSetups.Find(i => i.itemType == itemType);
            item.soInt.value -= amount ;

            if(item.soInt.value<0)
            {
                item.soInt.value = 0;
            }


        }

    }

    [System.Serializable]
    public class ItemSetup
    {
        public ItemType itemType;
        public SOInt soInt;
    }
}
