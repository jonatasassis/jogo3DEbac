using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 01;
    private string checkPointKey= "CheckPointKey";
    private bool checkPointActivated = false;
    public Text checkPointMessage;

    private void Awake()
    {
        checkPointMessage.text = "";
    }
    private void OnTriggerEnter(Collider col)
    {
        if (!checkPointActivated && col.transform.tag == "Player")
        {
            TurnOnCheckPoint();
            CheckCheckPoint();
        }
    }

    private void CheckCheckPoint()
    {
        SaveCheckPoint();
    }

    [NaughtyAttributes.Button]
    private void TurnOffCheckPoint()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }
    [NaughtyAttributes.Button]
    private void TurnOnCheckPoint()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
        SaveCheckPoint();
        checkPointMessage.text = "CheckPoint Ativado!";
       Invoke(nameof(MessageDelay),3f);
        print("liguei o checkpoint "+key);
    }

    private void SaveCheckPoint()
    {
        /* if (PlayerPrefs.GetInt(checkPointKey, 0) > key)
         {
             PlayerPrefs.SetInt(checkPointKey, key);
         }*/

        CheckPointManager.Instance.SaveLastCheckPoint(key);
        checkPointActivated = true;
    }

   private void MessageDelay()
    {
       
        
        checkPointMessage.text = "";
    }

}
