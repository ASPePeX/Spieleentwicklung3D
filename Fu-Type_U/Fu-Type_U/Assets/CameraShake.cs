using UnityEngine;

// ReSharper disable once CheckNamespace
public class CameraShake : MonoBehaviour
{
    private Vector3 _originPosition;
    private Quaternion _originRotation;
    private float _shakeDecay;
    private float _shakeIntensity;

    // ReSharper disable once UnusedMember.Local
    private void Update()
    {
        if (_shakeIntensity > 0)
        {
            transform.position = _originPosition + Random.insideUnitSphere*_shakeIntensity;
            transform.rotation = new Quaternion(
                _originRotation.x + Random.Range(-_shakeIntensity, _shakeIntensity)*0.1f,
                _originRotation.y + Random.Range(-_shakeIntensity, _shakeIntensity)*0.1f,
                _originRotation.z + Random.Range(-_shakeIntensity, _shakeIntensity)*0.1f,
                _originRotation.w + Random.Range(-_shakeIntensity, _shakeIntensity)*0.1f);
            _shakeIntensity -= _shakeDecay;
        }
    }


    public void Shake()
    {
        _originPosition = transform.position;
        _originRotation = transform.rotation;
        _shakeIntensity = 0.001f;
        _shakeDecay = 0.000001f;
    }
}
