using UnityEngine;

public class CameraController
{
    private Camera _camera;
    private GameObject _target;

    public CameraController(Camera camera, GameObject target)
    {
        _target = target;
        _camera = camera;
    }

    public void Update()
    {
        _camera.transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, _camera.transform.position.z);
    }
}
