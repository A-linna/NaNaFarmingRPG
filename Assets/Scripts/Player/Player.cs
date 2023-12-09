using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : SingletonMonoBehaviour<Player>
{
    //玩家输入
    private PlayerInputActions _playerInputActions;
    private PlayerInputActions.PlayerActions _playerActions;

    private Rigidbody2D _rigidbody;
    private Vector2 _move;

    [SerializeField] private float speed = 15;

    private const float RunMin = 0.7f;
    private const float WalkMin = 0.2f;


    private Enums _enums;
    private bool _isCarrying = false;

    //任务行走状态
    private bool _isWalking;
    private bool _isRunning;
    private bool _isIdle;

    //使用工具
    private bool _isUsingToolRight;
    private bool _isUsingToolLeft;
    private bool _isUsingToolUp;

    private bool _isUsingToolDown;

    //抬起工具
    private bool _isLiftingToolRight;
    private bool _isLiftingToolLeft;
    private bool _isLiftingToolUp;

    private bool _isLiftingToolDown;

    //拾取
    private bool _isPickingRight;
    private bool _isPickingLeft;
    private bool _isPickingUp;

    private bool _isPickingDown;

    //挥动工具
    private bool _isSwingingToolRight;
    private bool _isSwingingToolLeft;
    private bool _isSwingingToolUp;
    private bool _isSwingingToolDown;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInputActions = new PlayerInputActions();
        _playerActions = _playerInputActions.Player;
    }


    private void Update()
    {
        #region 玩家输入

        ResetAnimationTriggers();
        PlayerMoveInput();
        EventHandler.CallMovementEvent(_move.x, _move.y, _isWalking, _isRunning, _isIdle,
            _isCarrying, _enums,
            _isUsingToolRight, _isUsingToolLeft, _isUsingToolUp, _isUsingToolDown,
            _isLiftingToolRight, _isLiftingToolLeft, _isLiftingToolUp, _isLiftingToolDown,
            _isPickingRight, _isPickingLeft, _isPickingUp, _isPickingDown,
            _isSwingingToolRight, _isSwingingToolLeft, _isSwingingToolUp, _isSwingingToolDown,
            false, false, false, false);

        #endregion
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _move * speed;
    }


    private void PlayerMoveInput()
    {
        _move = _playerActions.Move.ReadValue<Vector2>();
        if (Vector2.zero != _move)
        {
            var x = Mathf.Abs(_move.x);
            var y = Mathf.Abs(_move.y);
            //  is walk
            if ((x is > WalkMin and < RunMin) || (y is > WalkMin and < RunMin))
            {
                _isWalking = true;
                _isRunning = false;
                _isIdle = false;
            }
            // is running
            else if (x >= RunMin || y >= RunMin)
            {
                _isWalking = false;
                _isRunning = true;
                _isIdle = false;
            }
        }
        else
        {
            _isWalking = false;
            _isRunning = false;
            _isIdle = true;
        }
    }


    private void ResetAnimationTriggers()
    {
        _isPickingRight = false;
        _isPickingLeft = false;
        _isPickingUp = false;
        _isPickingDown = false;
        _isUsingToolRight = false;
        _isUsingToolLeft = false;
        _isUsingToolUp = false;
        _isUsingToolDown = false;
        _isLiftingToolRight = false;
        _isLiftingToolLeft = false;
        _isLiftingToolUp = false;
        _isLiftingToolDown = false;
        _isSwingingToolRight = false;
        _isSwingingToolLeft = false;
        _isSwingingToolUp = false;
        _isSwingingToolDown = false;
        _enums = Enums.None;
    }


    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }
}