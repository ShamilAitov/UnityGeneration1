using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GeneratingObjects : MonoBehaviour
{
    [SerializeField] private Enemy _block;
    [SerializeField] private Transform _spawns;

    private Transform[] _spawnPoints;

    public void Start()
    {
        _spawnPoints = new Transform[_spawns.childCount];

        for (int i = 0; i < _spawns.childCount; i++)
        {
            _spawnPoints[i] = _spawns.GetChild(i);
        }

        StartCoroutine(GraduallyAppear());
    }

    private IEnumerator GraduallyAppear()
    {
        int spawnPointNamber;
        var waitForTwoSeconds = new WaitForSeconds(2F);

        while (true) 
        { 
            spawnPointNamber = Random.Range(0, _spawnPoints.Length);
            Instantiate(_block, _spawnPoints[spawnPointNamber].position, Quaternion.identity);

            yield return waitForTwoSeconds;
        }
    }
}
