using UnityEngine;

// ReSharper disable once CheckNamespace
public class PlayerMovement : MonoBehaviour
{
    private float _boundaryBottom;
    private float _boundaryLeft;
    private float _boundaryRight;
    private float _boundaryTop;
    private Vector2 _speedModifier;

// ReSharper disable once UnusedMember.Local
    private void Start()
    {
        _boundaryTop = 4.5f;
        _boundaryBottom = -4.5f;
        _boundaryLeft = 0;
        _boundaryRight = 16;
        _speedModifier = new Vector2(0.3f, 0.2f);
    }

// ReSharper disable once UnusedMember.Local
    private void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")*_speedModifier.x, Input.GetAxis("Vertical")*_speedModifier.y, 0);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, _boundaryLeft, _boundaryRight);
        pos.y = Mathf.Clamp(transform.position.y, _boundaryBottom, _boundaryTop);
        transform.position = pos;
    }
}