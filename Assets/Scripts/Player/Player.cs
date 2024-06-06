using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Singleton;
using Cloth;

public class Player :Singleton<Player>
{
    public Animator animPlayer;
    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravity = 9.8f;
    private float vSpeed = 0f;
    public float jumpSpeed = 15f;

    [Header("Life")]
    public HealthBase healtPlayer;
    private bool isAlive=true;
    public List<Collider> playerColliders;
    

    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;

    [Header("Flash")]
    public List<FlashColor> flashColorPlayer;

    [Header("Clothes")]
    [SerializeField]private ClothChanger clothChanger;

    private void OnValidate()
    {
        if(healtPlayer==null)
        {
            healtPlayer=GetComponent<HealthBase>();
        }
    }

    protected override void Awake()
    {
        base.Awake();
        OnValidate();
        healtPlayer.onDamage += Damage;
        healtPlayer.onKill += OnKill;

    }
   


    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * (turnSpeed*750) * Time.deltaTime, 0);
        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = -transform.forward * inputAxisVertical * (-speed*10);

        if (characterController.isGrounded)
        { 
            vSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            { 
                vSpeed = jumpSpeed; 
            } 
        }
        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;

        var isWalking = inputAxisVertical != 0;
        if (isWalking)
        { if (Input.GetKey(keyRun))
            { 
                speedVector *= speedRun;
                animPlayer.speed = speedRun;
            } 
            else
            { 
                animPlayer.speed = 1;
            }
        }
        characterController.Move(speedVector * Time.deltaTime);

        if (inputAxisVertical != 0)
        {
            animPlayer.SetBool("Run", true);
        } 
        else 
        {
            animPlayer.SetBool("Run", false);
        }
    }
    #region LIFE
    private void OnKill(HealthBase h)
    {
        if (isAlive)
        {
            isAlive = false;
            animPlayer.SetTrigger("Death");
            playerColliders.ForEach(i => i.enabled = false);

            Invoke(nameof(RevivePlayer), 1f);

        }


    }
    private void RevivePlayer()
    {
        isAlive = true;
        healtPlayer.ResetLife();
        animPlayer.SetTrigger("Revive");
       
        RespawnPlayer();
        Invoke(nameof(TurnOnColliders),.1f);
    }

    private void TurnOnColliders()
    {
        playerColliders.ForEach(i => i.enabled = true);
    }
    public void Damage(HealthBase h)
    {
        flashColorPlayer.ForEach(i=> i.Flash());
        EffectsManager.Instance.ChangeVignette();
        ShakeCamera.Instance.Shake();
    }

    public void Damage(float damageAmount, Vector3 dir)
    {
        //Damage(damageAmount);
    }
    #endregion

    [NaughtyAttributes.Button]
    public void RespawnPlayer()
    {
       if(CheckPointManager.Instance.hasCheckPoint()) 
        {
            transform.position = CheckPointManager.Instance.GetPositionFromLastCheckPoint();
        }
    }

    public void ChangeSpeed(float speed,float duration)
    {
        StartCoroutine(ChangeSpeedCoroutine(speed, duration));
    }

    IEnumerator ChangeSpeedCoroutine(float localSpeed,float duration)
    {
        var defautlSpeed = speed;
        speed = localSpeed;
        yield return new WaitForSeconds(duration);
        speed = defautlSpeed;
    }

    public void ChangeTexture(ClothSetup setup,float duration)
    {
        StartCoroutine(ChangeTextureCoroutine(setup, duration));
    }

    IEnumerator ChangeTextureCoroutine(ClothSetup setup, float duration)
    {
        clothChanger.ChangeTexture(setup);  
        yield return new WaitForSeconds(duration);
        clothChanger.ResetTexture(setup);
        
    }
}
