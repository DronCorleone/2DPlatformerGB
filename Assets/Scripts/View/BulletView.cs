using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trail;


    public void SetVisible(bool visible)
    {
        if (_trail)
        {
            _trail.enabled = visible;
        }

        if (!_trail)
        {
            _trail.Clear();
        }


        GetComponent<Rigidbody2D>().isKinematic = !visible;
        GetComponentInChildren<SpriteRenderer>().enabled = visible;
    }
}