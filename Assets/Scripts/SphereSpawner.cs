using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private Sphere _prefab;
    [SerializeField] private float _height;
    [SerializeField] private int _maxSpawnedSphere;
    public UnityEvent<int> SphereSpawned;
    private int _sphereAmount= 0;


    public void MultiSpawn(int count)
    {
        if (count < 0)
            return;
        if ((_sphereAmount + count) > _maxSpawnedSphere)
            count = _maxSpawnedSphere - _sphereAmount;

        for (int i = 0; i < count; i++)
        {
            Spawn();
        }
    }
    private void Spawn()
    {
        var sphere = Instantiate(_prefab, RandomlyPosition(), Quaternion.identity);
        sphere.Death += DecrementAmountOfSphere;
        _sphereAmount++;
        SphereSpawned?.Invoke(_sphereAmount);
    }
    private Vector3 RandomlyPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-10f, 10f), _height, UnityEngine.Random.Range(-10f, 10f));
    }
    private void DecrementAmountOfSphere()
    {
        _sphereAmount -= 1;
        SphereSpawned?.Invoke(_sphereAmount);
    }
}
