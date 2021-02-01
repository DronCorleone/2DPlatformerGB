using System.Collections.Generic;
using UnityEngine;

public class BulletsEmitterController
{
    private GameSettings _settings;

    private List<BulletMoveController> _bullets = new List<BulletMoveController>();
    private Transform _transform;

    private int _currentIndex;
    private float _timeTillNextBullet;

    private bool _isActive;

    public BulletsEmitterController(List<BulletView> bulletViews, Transform transform, GameSettings settings)
    {
        _settings = settings;
        _transform = transform;

        foreach (BulletView bulletView in bulletViews)
        {
            _bullets.Add(new BulletMoveController(bulletView));
        }
    }

    public void Update()
    {
        if (!_isActive) return;

        if (_timeTillNextBullet > 0)
        {
            _timeTillNextBullet -= Time.deltaTime;
        }
        else
        {
            _timeTillNextBullet = _settings.FireInterval;
            _bullets[_currentIndex].Throw(_transform, _transform.up * _settings.BulletStartSpeed);
            _currentIndex++;

            if (_currentIndex >= _bullets.Count)
            {
                _currentIndex = 0;
            }
        }
    }
}