

using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    [SerializeField] private float _moveDistance;
    [SerializeField] private float _speed = 1f;
    
    private Vector3 _moveDirection = Vector3.forward;
    private float _distanceCovered = 0f;

    private void Update()
    {
        float step = _speed * Time.deltaTime;
        transform.Translate(_moveDirection.normalized * step);
        _distanceCovered += step;

        if (_distanceCovered >= _moveDistance)
        {
            _distanceCovered = 0;
            _moveDirection = Vector3.back == _moveDirection ? Vector3.forward : Vector3.back;
        }
    }
}