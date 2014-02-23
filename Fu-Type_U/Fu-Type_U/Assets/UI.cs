using System.Globalization;
using UnityEngine;

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
public class UI : MonoBehaviour
{
    private static string _curWeapon;

    private Transform _camera;
    private Vector3 _originPosition;
    private Quaternion _originRotation;
    public Transform Player;
    private int _score;
    private float _shakeDecay;
    private float _shakeIntensity;

    public static string CurWeapon
    {
        set { _curWeapon = value; }
    }

// ReSharper disable once UnusedMember.Local
    private void Start()
    {
        _camera = Camera.main.transform;
        StartCoroutine(Config.LoadConfig());
    }

    public void OnGUI()
    {
        if (Config.CurGameState == (int) GameState.NotRunning)
        {
            GUI.BeginGroup(new Rect(Screen.width/2 - 100, 200, 200, 200));
            GUI.Label(new Rect(35, 5, 190, 20), "Welcome to Fu-Type U");
            if (GUI.Button(new Rect(70, 55, 50, 20), "Start"))
            {
                Config.CurGameState = (int) GameState.Running;
                _score = 0;
                var player = Instantiate(Player, Vector3.zero, Quaternion.identity) as Transform;
                if (player != null) player.parent = gameObject.transform;
            }
            GUI.EndGroup();
        }
        if (Config.CurGameState == (int) GameState.Running)
        {
            GUI.BeginGroup(new Rect(20, 20, 200, 200));
            GUI.Label(new Rect(35, 5, 190, 20), "Current Weapon:");
            GUI.Label(new Rect(35, 20, 190, 20), _curWeapon);
            GUI.Label(new Rect(35, 40, 190, 20), "Score:");
            GUI.Label(new Rect(35, 55, 190, 20), _score.ToString(CultureInfo.InvariantCulture));
            GUI.EndGroup();
        }

        if (_shakeIntensity > 0)
        {
            _camera.position = _originPosition + Random.insideUnitSphere*_shakeIntensity;
            _camera.rotation = new Quaternion(
                _originRotation.x + Random.Range(-_shakeIntensity, _shakeIntensity)*0.1f,
                _originRotation.y + Random.Range(-_shakeIntensity, _shakeIntensity)*0.1f,
                _originRotation.z + Random.Range(-_shakeIntensity, _shakeIntensity)*0.1f,
                _originRotation.w + Random.Range(-_shakeIntensity, _shakeIntensity)*0.1f);
            _shakeIntensity -= _shakeDecay;
        }
    }

    public void AddScore(int add)
    {
        _score += add;
    }

    public void Shake()
    {
        _originPosition = _camera.position;
        _originRotation = _camera.rotation;
        _shakeIntensity = 0.2f;
        _shakeDecay = 0.005f;
        BroadcastMessage("SelfDestruct");
    }
}