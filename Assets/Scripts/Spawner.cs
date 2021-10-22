using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private GameObject _enemy;
    
    private Transform []_points;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        StartCoroutine(CreateEnemies());
    }

    private IEnumerator CreateEnemies()
    {
        float runningTime = 2f;

        for (int i = 0; i < _points.Length; i++)
        {
            yield return new WaitForSeconds(runningTime);

            Instantiate(_enemy, _points[i]);
        }        
    }
}
