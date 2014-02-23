using UnityEngine;

// ReSharper disable once CheckNamespace
public class ExplosionBehavious : MonoBehaviour
{
// ReSharper disable once UnusedMember.Local
    private void Start()
    {
        audio.Play();
    }

// ReSharper disable once UnusedMember.Local
    private void Update()
    {
        if (!audio.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}