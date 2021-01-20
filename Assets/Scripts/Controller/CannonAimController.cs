﻿using UnityEngine;

public class CannonAimController
{
    private Transform _muzzleTransform;
    private Transform _aimTransform;

    private Vector3 _dir;
    private float _angle;
    private Vector3 _axis;

    public CannonAimController (Transform muzzleTransform, Transform aimTransform)
    {
        _muzzleTransform = muzzleTransform;
        _aimTransform = aimTransform;
    }

    public void Update()
    {
        _dir = _aimTransform.position - _muzzleTransform.position;
        _angle = Vector3.Angle(Vector3.up, _dir);
        _axis = Vector3.Cross(Vector3.up, _dir);
        _muzzleTransform.rotation = Quaternion.AngleAxis(_angle, _axis);
    }
}