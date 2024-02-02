using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] private Balloon _balloonPrefab;

    private Vector2 _spawnPosition;

    private float _spawnRate = 1.5f;
    private float _spawnTime = 0;

    private void Update()
    {
        Spawn();
    }
    private void Spawn()
    {
        if (Time.time > _spawnTime)
        {
            _spawnRate = Mathf.Clamp(_spawnRate - 0.01f, 0.3f, 1.5f);
            _spawnTime = Time.time +  _spawnRate;

     
           
            _spawnPosition = new Vector2(Random.Range(CameraSize.xMin, CameraSize.xMax), CameraSize.yMin);
            Balloon balloon = Instantiate(_balloonPrefab);
            balloon.transform.position = _spawnPosition;
        }
    }
}
