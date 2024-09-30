using UnityEngine;
public class CameraHandler : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 3.0f;

    [SerializeField]
    private Vector2 _zoomMinMax = new Vector2(0.5f, 15);

    private Vector2 _rotation = new Vector2();

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distanceFromTarget = 3.0f;

    private Vector3 _currentRotation;

    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-40, 40);

    public void SetTarget(Transform target)
    {
        _target = target;
        ApplyFrameRotation(Vector2.zero);
    }

    void LateUpdate()
    {
        ApplyZoom(Input.mouseScrollDelta.y);

        if(Input.GetMouseButton(0))
        {
            ApplyFrameRotation(new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")));
        }
    }

    private void ApplyFrameRotation(Vector2 frameRotation)
    {
        _rotation += frameRotation * _mouseSensitivity;

        _rotation.x = Mathf.Clamp(_rotation.x, _rotationXMinMax.x, _rotationXMinMax.y);

        _currentRotation = new Vector3(-_rotation.x, _rotation.y, 0);
        transform.localEulerAngles = _currentRotation;

        transform.position = _target.position - transform.forward * _distanceFromTarget;
    }

    private void ApplyZoom(float frameValue)
    {

        if(_distanceFromTarget - frameValue < _zoomMinMax.x || _distanceFromTarget - frameValue > _zoomMinMax.y)
        {
            return;
        }

        _distanceFromTarget -= frameValue;

        transform.position = _target.position - transform.forward * _distanceFromTarget;
    }

}