using UnityEngine.InputSystem;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    [SerializeField] private bool targetMouse;
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed;

    void Update()
    {
        Quaternion rotation = GetRotationQuaternion();
        transform.rotation = Quaternion.Slerp(transform.rotation, GetRotationQuaternion(), rotationSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private Quaternion GetRotationQuaternion()
    {
        Vector2 targetDirection = GetTargetDirection();
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg + 90f;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    private Vector2 GetTargetDirection()
    {
        return (targetMouse ? Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) : target.position) - transform.position;
    } 
}
