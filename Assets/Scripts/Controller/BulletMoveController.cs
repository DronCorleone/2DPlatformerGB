using UnityEngine;

public class BulletMoveController
{
    private BulletView _bullet;


    public BulletMoveController (BulletView bullet)
    {
        _bullet = bullet;
        _bullet.SetVisible(false);
    }

    public void Throw(Transform transform, Vector3 velocity)
    {
        Rigidbody2D bulletRigidbody = _bullet.GetComponent<Rigidbody2D>();
        _bullet.SetVisible(false);
        _bullet.transform.position = transform.position;
        _bullet.transform.rotation = transform.rotation;
        bulletRigidbody.velocity = Vector2.zero;
        bulletRigidbody.angularVelocity = 0;
        
        _bullet.SetVisible(true);
        bulletRigidbody.AddForce(velocity, ForceMode2D.Impulse);
    }
}