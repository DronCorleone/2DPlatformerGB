using UnityEngine;

public class CameraController
{
    private Camera _camera;
    private GameObject _target;

    private Vector3 _velocity = Vector3.zero;
    private float _smoothTime = 0.15f;

    public CameraController(Camera camera, GameObject target)
    {
        _target = target;
        _camera = camera;
    }

    public void FixedUpdate()
    {
        _camera.transform.position = Vector3.SmoothDamp(_camera.transform.position, new Vector3(_target.transform.position.x, _target.transform.position.y, _camera.transform.position.z), ref _velocity, _smoothTime);
    }
}