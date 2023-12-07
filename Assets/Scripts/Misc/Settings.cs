using UnityEngine;

/**
 * 基本参数的设置
 */
public class Settings
{

    //item 淡入 淡出 设置
    //淡入 时间
    public const float fadeInSeconds = 0.5f;
    //淡出时间
    public const float fadeOutSeconds = 0.6f;
    //透明度
    public const float targetAlpha = 0.4f;

    //玩家初始库存容量
    public static int playerInitialInventoryCapacity = 24;
    //最大库存容量
    public static int playerMaximumInventoryCapacity = 48;




    //动画参数
    public static int xInput;
    public static int yInput;
    public static int isWalking;
    public static int isRunning;
    public static int toolEffect;
    public static int isUsingToolUp;
    public static int isUsingToolDown;
    public static int isUsingToolRight;
    public static int isUsingToolLeft;
    public static int isSwingingToolUp;
    public static int isSwingingToolDown;
    public static int isSwingingToolRight;
    public static int isSwingingToolLeft;
    public static int isLiftingToolUp;
    public static int isLiftingToolDown;
    public static int isLiftingToolRight;
    public static int isLiftingToolLeft;
    public static int isHoldingToolUp;
    public static int isHoldingToolDown;
    public static int isHoldingToolRight;
    public static int isHoldingToolLeft;
    public static int isPickingUp;
    public static int isPickingDown;
    public static int isPickingRight;
    public static int isPickingLeft;
    public static int idleUp;
    public static int idleDown;
    public static int idleLeft;
    public static int idleRight;

    static Settings()
    {
        xInput = Animator.StringToHash("xInput");
        yInput = Animator.StringToHash("yInput");
        isWalking = Animator.StringToHash("isWalking");
        isRunning = Animator.StringToHash("isRunning");
        toolEffect = Animator.StringToHash("toolEffect");
        isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        isUsingToolDown = Animator.StringToHash("isUsingToolDown");
        isUsingToolRight = Animator.StringToHash("isUsingToolRight");
        isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
        isSwingingToolUp = Animator.StringToHash("isSwingingToolUp");
        isSwingingToolDown = Animator.StringToHash("isSwingingToolDown");
        isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");
        isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft");
        isLiftingToolUp = Animator.StringToHash("isLiftingToolUp");
        isLiftingToolDown = Animator.StringToHash("isLiftingToolDown");
        isLiftingToolRight = Animator.StringToHash("isLiftingToolRight");
        isLiftingToolLeft = Animator.StringToHash("isLiftingToolLeft");
        isHoldingToolUp = Animator.StringToHash("isHoldingToolUp");
        isHoldingToolDown = Animator.StringToHash("isHoldingToolDown");
        isHoldingToolRight = Animator.StringToHash("isHoldingToolRight");
        isHoldingToolLeft = Animator.StringToHash("isHoldingToolLeft");
        isPickingUp = Animator.StringToHash("isPickingUp");
        isPickingDown = Animator.StringToHash("isPickingDown");
        isPickingRight = Animator.StringToHash("isPickingRight");
        isPickingLeft = Animator.StringToHash("isPickingLeft");
        idleUp = Animator.StringToHash("idleUp");
        idleDown = Animator.StringToHash("idleDown");
        idleLeft = Animator.StringToHash("idleLeft");
        idleRight = Animator.StringToHash("idleRight");
    }
}