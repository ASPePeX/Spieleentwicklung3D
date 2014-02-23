using UnityEngine;

// ReSharper disable once CheckNamespace
public class Collision : MonoBehaviour
{
    public Transform ExplosionEmiter;
    // ReSharper disable once UnusedMember.Local
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag.Equals("Player") &&
            (other.gameObject.transform.tag.Contains("Enemy") || other.gameObject.tag.Equals("EnemyShot")))
        {
            Config.CurGameState = (int) GameState.NotRunning;
            SendMessageUpwards("Shake");
            Instantiate(ExplosionEmiter, transform.position, Quaternion.identity);
            Destroy(other.gameObject.transform.parent.gameObject);
            Destroy(gameObject.transform.parent.gameObject);
        }
        else if (gameObject.tag.Equals("Enemy") &&
                 (other.gameObject.transform.parent.tag.Contains("Player") || other.gameObject.tag.Equals("PlayerShot")))
        {
            Instantiate(ExplosionEmiter, transform.position, Quaternion.identity);
            Destroy(other.gameObject.transform.parent.gameObject);
            Destroy(gameObject.transform.parent.gameObject);
            SendMessageUpwards("AddScore", 10);
        }
    }
}