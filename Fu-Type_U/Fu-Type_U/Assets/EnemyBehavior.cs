using UnityEngine;

// ReSharper disable once CheckNamespace
public class EnemyBehavior : MonoBehaviour
{
// ReSharper disable once UnusedMember.Local
    private void Update()
    {
        transform.Translate(-0.1f, 0, 0);
        if (transform.position.x < -4)
            Destroy(gameObject);
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
