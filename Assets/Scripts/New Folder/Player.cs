using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public int velMovPlayer;
    public Vector3 posInicialPlayer;
    public GameObject player;
    public MeshRenderer materialPlayer;
    public bool canMove=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)&&canMove==true)
        {
           
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z+1);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
           
            player.transform.DOMoveY(12, 2);
        }
    }

    public void MudarCor(Color c)
    {
        materialPlayer.material.SetColor("Base Color",c);
    }
}
