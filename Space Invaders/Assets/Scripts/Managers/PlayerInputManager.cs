using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : ObservableSubject
{
    public Player player;
    public ShootingController shooting;
    
    public void OnMove(InputAction.CallbackContext context)
    {
        player.AddVelocity(context.ReadValue<Vector2>());
        ObserveOnMove(context);
    }

    private void ObserveOnMove(InputAction.CallbackContext context)
    {
        if (context.started) NotifyObservers(ObservableActions.PlayerStartsMoving);
        if (context.performed) NotifyObservers(ObservableActions.PlayerMoving);
        if (context.canceled) NotifyObservers(ObservableActions.PlayerStopsMoving);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed) shooting.Shoot(player.transform.rotation);
    }
}
