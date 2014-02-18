using System.Reflection;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class ShotBehaviour : MonoBehaviour
{
    public float _speedDirection;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x > -5 && transform.position.x < 35)
        {
            transform.Translate(_speedDirection * Time.deltaTime, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}