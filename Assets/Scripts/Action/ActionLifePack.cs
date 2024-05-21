using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

public class ActionLifePack : MonoBehaviour
{
    public SOInt soInt;
    public KeyCode keycode = KeyCode.L;

    // Start is called before the first frame update
    void Start()
    {
        soInt= ItemManager.Instance.GetItemByType(ItemType.LIFE_PACK).soInt;
    }

    private void RecoverLife()
    {
        if(soInt.value>0)
        {
            ItemManager.Instance.RemoveByType(ItemType.LIFE_PACK);
            Player.Instance.healtPlayer.ResetLife();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(keycode))
        {
            RecoverLife();
        }
    }
}
