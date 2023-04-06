using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T _prefab;
    private int _SpawnCount;
    private List<T> _spawnedList;
    private Vector3 _startPrefabPosition;
    private bool _isDynamic;
    private Quaternion _prefabRotation;
    private Transform _prefabContainer;

    public int LastActiveIndex { get; private set; }
    public readonly List<T> SpawnedList;
    

    public ObjectPool(T prefab, int spawnCount, bool isDynamic = false)
    {
        _prefab = prefab;
        _SpawnCount = spawnCount;
        _isDynamic = isDynamic;
        _spawnedList = new List<T>(_SpawnCount);
        SpawnedList = _spawnedList;
    }

    public void Init(Vector3 position, Quaternion rotation, Transform container)
    {
        _startPrefabPosition = position;
        _prefabRotation = rotation;
        _prefabContainer = container;

        for (int i = 0; i < _SpawnCount; i++)
            SpawnObject();
    }

    public void ActivateObject(int activateCount = 1)
    {
        if (activateCount > _spawnedList.Count)
            return;

        for (int i = 0; i < activateCount; i++)
        {
            _spawnedList[LastActiveIndex++].gameObject.SetActive(true);

            if (LastActiveIndex >= _spawnedList.Count)
            {
                Debug.Log("all objects in pull are active, index was reseted");
                LastActiveIndex = 0;
            }

            if (_spawnedList[LastActiveIndex].gameObject.activeSelf)
            {
                Debug.Log("Object already active, index was reseted");
                LastActiveIndex = 0;
            }
        }
    }

    public void DeactivateObject(MonoBehaviour obj)
    {
        _spawnedList[GetObjectIndex(obj)].gameObject.SetActive(false);
        obj.gameObject.transform.position = _startPrefabPosition;
    }

    public T GetObjectFromPool(int index)
    {
        if (index <= -1 || index > _spawnedList.Capacity)
            throw new Exception("List doesnt have Object at this index");

        return _spawnedList[index];
    }

    public T GetLastSpawnedObject()
    {
        return _spawnedList[LastActiveIndex];
    }

    //TODO add dynamic increase option
    public void IncreasePoolCapacity()
    {
        _SpawnCount *= 2;

        for(int i = _spawnedList.Count; i < _SpawnCount; i++)
            SpawnObject();
    }

    public int GetObjectIndex(MonoBehaviour obj)
    {
        for (int i = 0; i < _spawnedList.Count; i++)
        {
            if (_spawnedList[i] == obj)
                return i;
        }

        return -1;
    }

    private void SpawnObject()
    {
        T spawned;
        spawned = UnityEngine.Object.Instantiate(_prefab, _startPrefabPosition, _prefabRotation, _prefabContainer);
        spawned.gameObject.SetActive(false);
        _spawnedList.Add(spawned);
    }
}
