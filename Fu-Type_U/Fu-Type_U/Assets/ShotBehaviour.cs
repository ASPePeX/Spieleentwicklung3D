using UnityEngine;

// ReSharper disable once CheckNamespace
public class ShotBehaviour : MonoBehaviour
{
    public float SpeedDirection;


// ReSharper disable once UnusedMember.Local
    private void Start()
    {
        audio.Play();
    }


// ReSharper disable once UnusedMember.Local
    private void Update()
    {
        if (transform.position.x > -5 && transform.position.x < 35)
        {
            transform.Translate(SpeedDirection*Time.deltaTime, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}