using UnityEngine;

// ReSharper disable once CheckNamespace
public class EnemySpawner : MonoBehaviour
{
    public Transform Enemy;
    private float _enemyTimer = 5f;
    private float _curTimer;

// ReSharper disable once UnusedMember.Local
    private void Update()
    {
        if (Config.CurGameState == (int) GameState.Running)
        {
            _curTimer -= Time.deltaTime;
            if (_curTimer <= 0)
            {
                _curTimer = _enemyTimer;
                _enemyTimer -= _enemyTimer/20;
                var enemy =
                    Instantiate(Enemy, new Vector3(35, Random.Range(-8, 8), 0), Quaternion.identity) as Transform;
                if (enemy != null) enemy.parent = gameObject.transform;
                Debug.Log(_enemyTimer);
            }
        }
    }
}
