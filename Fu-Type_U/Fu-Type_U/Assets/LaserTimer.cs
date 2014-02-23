using UnityEngine;

// ReSharper disable once CheckNamespace
public class LaserTimer : MonoBehaviour
{
    private float _timer;
    private float _startTimer = 0.05f;

// ReSharper disable once UnusedMember.Local
    private void Start()
    {
        _timer = _startTimer;
    }

// ReSharper disable once UnusedMember.Local
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                gameObject.SetActive(false);
                _timer = _startTimer;
            }
        }
    }
}
