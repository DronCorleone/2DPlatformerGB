using UnityEngine;

public class BulletMoveController
{
    private GameSettings _settings;

    private float _radius = 0.3f;
    private Vector3 _velocity;

    private float _groundLevel = -2f;

    private BulletView _bullet;
    private Vector3 _bulletsStorage = new Vector3(-10, -10, 0);

    public BulletMoveController (BulletView bullet, GameSettings settings)
    {
        _bullet = bullet;
        _bullet.SetVisible(false);
        _settings = settings;
    }

    public void Update()
    {
        if (IsGrounded())
        {
            SetVelocity(_velocity.Change(y: -_velocity.y));
            _bullet.transform.position = _bullet.transform.position.Change(y: _groundLevel + _radius);
        }
        else
        {
            SetVelocity(_velocity + Vector3.up * _settings.G * Time.fixedDeltaTime);
            _bullet.transform.position += _velocity * Time.fixedDeltaTime;
        }
    }

    public void Throw(Vector3 position, Vector3 velocity)
    {
        _bullet.transform.position = position;
        SetVelocity(velocity);
        _bullet.SetVisible(true);
    }

    private void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
        var angle = Vector3.Angle(Vector3.left, _velocity);
        var axis = Vector3.Cross(Vector3.left, _velocity);
        _bullet.transform.rotation = Quaternion.AngleAxis(angle, axis);

    }

    private bool IsGrounded()
    {
        return _bullet.transform.position.y <= _groundLevel + _radius + float.Epsilon && _velocity.y <= 0;
    }

    private void BackOnTheStorage()
    {
        _bullet.SetVisible(false);
        _bullet.transform.position = _bulletsStorage;
    }
}