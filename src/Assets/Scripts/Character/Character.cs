using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Character : MonoBehaviour
{
    /// <summary>
    /// 玩家角色动作管理器名
    /// </summary>
    internal const string AniName_CharState = "PlayerCharState";

    float speed = 1500.0f;   //移动速度

    float jumpForce = 8000.0f;   //跳跃力

    Animator _CharAnimator = null;

    Transform _CharTransform = null;

    RectTransform _CharRectTransform = null;

    CapsuleCollider2D _CapsuleCollider2D = null;

    Rigidbody2D _Rigidbody2D = null;

    private void Awake()
    {

    }

    private void Initialization()
    {
        _CharAnimator = gameObject.GetComponent<Animator>();
        AniState = PlayerCharAnimationState.Stand;
        _CapsuleCollider2D = this.GetComponent<CapsuleCollider2D>();
        _Rigidbody2D = this.GetComponent<Rigidbody2D>();
        _CharTransform = gameObject.GetComponent<Transform>();
        _CharRectTransform = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
        AddEventHandler();
    }

    bool isJumping = false;
    bool isAttacking = false;
    bool isMoving = false;

    private void Update()
    {
        //cap.Raycast
        Vector2 vec = _Rigidbody2D.velocity;
        var vecX = Input.GetAxis("Horizontal");
        var vecY = Input.GetAxis("Vertical");
        var sc = _CharTransform.localScale;
        float scaleX = 0;
        float scaleY = sc.y;
        var speedY = _Rigidbody2D.velocity.y;
        if(Input.GetKeyUp(KeyCode.X))
        {
            isAttacking = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var normalLine = collision.contacts[0].normal;
        var currentDir = transform.TransformDirection(Vector2.right);
        //var dir = Vector2.Reflect(normalLine);
        Debug.Log(normalLine);
        Debug.Log(currentDir);
        if (collision.collider.tag == "Ground" && normalLine.y > 0)
        {
            isJumping = false;
            if (_Rigidbody2D.velocity.x < -0.10f)
            {
                AniState = PlayerCharAnimationState.WalkLeft;
                _CharAnimator.SetInteger(AniName_CharState, 1);
            }
            else if (_Rigidbody2D.velocity.x > 0.10f)
            {
                AniState = PlayerCharAnimationState.WalkRight;
                _CharAnimator.SetInteger(AniName_CharState, 1);
            }
            else
            {
                AniState = PlayerCharAnimationState.Stand;
                _CharAnimator.SetInteger(AniName_CharState, 0);
            }
            Debug.Log("碰撞地板,解除跳跃");
        }
    }

    void ResetAttackState()
    {
        isAttacking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var vecX = Input.GetAxis("Horizontal");
        var vecY = Input.GetAxis("Vertical");
        var sc = _CharTransform.localScale;
        float scaleX = 0;
        float scaleY = sc.y;
        var speedY = _Rigidbody2D.velocity.y;
        bool isDoubleDir = Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow);
        bool isLeft = _CharTransform.localScale.x > 0;
        if (isJumping == false)
        {
            if (Input.GetKey(KeyCode.C))
            {
                isJumping = true;
                //coli.enabled = false;
                _Rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                //rg.velocity = new Vector2(rg.velocity.x, jumpForce * Time.deltaTime);
                _CharAnimator.SetInteger(AniName_CharState, 2);
                AniState = PlayerCharAnimationState.Jump;
                //Invoke("ResetCollider", 0.5f);
            }
            if (Input.GetKey(KeyCode.X) && isAttacking == false && isMoving == false)
            {
                Debug.Log("攻击");
                isAttacking = true;
                _CharAnimator.SetInteger(AniName_CharState, 3);
                AniState = PlayerCharAnimationState.Attack;
                Invoke("ResetAttackState", 0.6f);
            }
        }
        else
        {

        }

        if (Input.GetKey(KeyCode.LeftArrow) && isDoubleDir == false && isAttacking == false)
        {
            //rg.velocity = new Vector2(vecX * speed, rg.velocity.y);

            if (Input.GetKey(KeyCode.X))
            {
                Debug.Log("攻击");
                isAttacking = true;
                _CharAnimator.SetInteger(AniName_CharState, 3);
                AniState = PlayerCharAnimationState.Attack;
                Invoke("ResetAttackState", 0.6f);
            }
            else
            {
                _Rigidbody2D.AddForce(new Vector2(vecX * speed, 0), ForceMode2D.Impulse);
                scaleX = sc.x > 0 ? -sc.x : sc.x;
                _CharTransform.localScale = new Vector2(scaleX, scaleY);
                //if (AniState == PlayerCharAnimationState.WalkRight)
                //{
                //    _CharTransform.localPosition = new Vector2(_CharTransform.localPosition.x + 0.8f, _CharTransform.localPosition.y);
                //}
                //else if (AniState == PlayerCharAnimationState.Stand)
                //{
                //    if(isLeft == false) _CharTransform.localPosition = new Vector2(_CharTransform.localPosition.x + 0.8f, _CharTransform.localPosition.y);
                //}

                if (isJumping)
                {

                }
                else
                {
                    AniState = PlayerCharAnimationState.WalkLeft;
                    _CharAnimator.SetInteger(AniName_CharState, 1);
                }
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) && isDoubleDir == false && isAttacking == false)
        {
            //rg.velocity = new Vector2(vecX * speed, rg.velocity.y);
            if (Input.GetKey(KeyCode.X))
            {
                Debug.Log("攻击");
                isAttacking = true;
                _CharAnimator.SetInteger(AniName_CharState, 3);
                AniState = PlayerCharAnimationState.Attack;
                Invoke("ResetAttackState", 0.6f);
            }
            else
            {
                _Rigidbody2D.AddForce(new Vector2(vecX * speed, 0), ForceMode2D.Impulse);
                scaleX = Math.Abs(sc.x);
                _CharTransform.localScale = new Vector2(scaleX, scaleY);
                //if (AniState == PlayerCharAnimationState.WalkLeft)
                //{
                //    _CharTransform.localPosition = new Vector2(_CharTransform.localPosition.x - 0.8f, _CharTransform.localPosition.y);
                //}
                //else if (AniState == PlayerCharAnimationState.Stand)
                //{
                //    if (isLeft) _CharTransform.localPosition = new Vector2(_CharTransform.localPosition.x - 0.8f, _CharTransform.localPosition.y);
                //}
                if (isJumping)
                {

                }
                else
                {
                    AniState = PlayerCharAnimationState.WalkRight;
                    _CharAnimator.SetInteger(AniName_CharState, 1);
                }
            }


        }
        if (isDoubleDir && isJumping == false)
        {
            _CharAnimator.SetInteger(AniName_CharState, 0);
            AniState = PlayerCharAnimationState.Stand;
        }
        if (Math.Abs(vecX) < 0.30f && Math.Abs(speedY) < 0.30f && isAttacking == false && isJumping == false)
        {
            _CharAnimator.SetInteger(AniName_CharState, 0);
            AniState = PlayerCharAnimationState.Stand;
        }
    }

    private void AddEventHandler()
    {

    }

    /// <summary>
    /// 杀死自己
    /// </summary>
    public virtual void Kill()
    {
        Destroy(gameObject);
    }

    PlayerCharAnimationState AniState { get; set; }

    /// <summary>
    /// 角色朝向
    /// </summary>
    PlayerCharFace Face
    {
        get
        {
            if (_CharTransform.localScale.x > 0)
                return PlayerCharFace.Right;
            else
                return PlayerCharFace.Left;
        }
    }
}

/// <summary>
/// 玩家角色动作状态
/// </summary>
enum PlayerCharAnimationState
{ 
    Stand,
    WalkLeft,
    WalkRight,
    Jump,
    Attack,
}

/// <summary>
/// 角色朝向
/// </summary>
enum PlayerCharFace
{ 
    Left,
    Right,
}
