using UnityEngine;

// ReSharper disable once CheckNamespace
public class Collision : MonoBehaviour
{
    // ReSharper disable once UnusedMember.Local
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag.Equals("Player") && (other.gameObject.transform.parent.tag.Contains("Enemy") || other.gameObject.tag.Equals("EnemyShot")))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (gameObject.tag.Equals("Enemy") && (other.gameObject.transform.parent.tag.Contains("Player") || other.gameObject.tag.Equals("PlayerShot")))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}