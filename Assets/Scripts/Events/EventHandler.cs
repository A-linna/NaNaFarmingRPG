using System;
using System.Collections.Generic;

public delegate void MovementDelegate(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle,
    bool isCarrying, Enums enums,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
    bool idleUp, bool idleDown, bool idleLeft, bool idleRight);


public static class EventHandler
{
    public static event MovementDelegate MovementEvent;

    //库存更新事件
    public static Action<InventoryLocation, List<InventoryItem>> InventoryUpdateEvent;


    public static void CallInventoryUpdateEvent(InventoryLocation inventoryLocation, List<InventoryItem> inventoryItems) {
        if (InventoryUpdateEvent != null) {
            InventoryUpdateEvent.Invoke(inventoryLocation, inventoryItems);
        }
    }

    public static void CallMovementEvent(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle,
        bool isCarrying, Enums enums,
        bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
        bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
        bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
        bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
        bool idleUp, bool idleDown, bool idleLeft, bool idleRight)
    {
        MovementEvent?.Invoke(inputX, inputY, isWalking, isRunning, isIdle,
            isCarrying, enums,
            isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
            isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
            isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
            isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
            idleUp, idleDown, idleLeft, idleRight);
    }
}