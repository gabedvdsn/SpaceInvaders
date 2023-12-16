using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : ObservableSubject
{
    private bool acceptingInput = true;
    
    public Player player;
    public ShootingController shooting;

    public void SetAcceptingInput(bool flag)
    {
        acceptingInput = flag;
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!acceptingInput) return;
        
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
        if (!acceptingInput) return;
        
        if (context.performed) shooting.Shoot(player.transform.rotation);
    }

    void ObserveFire(InputAction.CallbackContext context) => NotifyObservers(ObservableActions.PlayerFires);
}
