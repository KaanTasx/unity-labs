using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _moveDirection;
    
    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");   

        _moveDirection = new Vector3(moveX, 0, moveZ);

        transform.Translate(_moveDirection * (_speed * Time.deltaTime));
    }
}