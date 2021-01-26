using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trail;

    private void Start()
    {
        SetVisible(false);
    }

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

        GetComponentInChildren<SpriteRenderer>().enabled = visible;
    }
}