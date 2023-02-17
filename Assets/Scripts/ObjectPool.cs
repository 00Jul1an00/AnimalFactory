using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T _prefab;
    private int _SpawnCount;
    private List<T> _SpawnedList;
    private Vector3 _startPrefabPosition;
    private bool _isDynamic;
    private Quaternion _prefabRotation;
    private Transform _prefabContainer;

    public int LastActiveIndex { get; private set; }

    

    public ObjectPool(T prefab, int spawnCount, bool isDynamic = false)
    {
        _prefab = prefab;
        _SpawnCount = spawnCount;
        _isDynamic = isDynamic;
        _SpawnedList = new List<T>(_SpawnCount);
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
        if (activateCount > _SpawnedList.Count)
            return;

        for (int i = 0; i < activateCount; i++)
        {
            _SpawnedList[LastActiveIndex++].gameObject.SetActive(true);

            if (LastActiveIndex >= _SpawnedList.Count)
            {
                Debug.Log("all objects in pull are active, index was reseted");
                LastActiveIndex = 0;
            }

            if (_SpawnedList[LastActiveIndex].gameObject.activeSelf)
            {
                Debug.Log("Object already active, index was reseted");
                LastActiveIndex = 0;
            }
            Debug.Log(LastActiveIndex);
        }
    }

    public void DeactivateObject(MonoBehaviour obj)
    {
        _SpawnedList[GetObjectIndex(obj)].gameObject.SetActive(false);
        obj.gameObject.transform.position = _startPrefabPosition;
    }

    public T GetObjectFromPool(int index)
    {
        if (index <= -1 || index > _SpawnedList.Capacity)
            throw new Exception("List doesnt have Object at this index");

        return _SpawnedList[index];
    }

    public T GetLastSpawnedObject()
    {
        return _SpawnedList[LastActiveIndex];
    }

    //TODO add dynamic increase option
    public void IncreasePoolCapacity()
    {
        _SpawnCount *= 2;

        for(int i = _SpawnedList.Count; i < _SpawnCount; i++)
            SpawnObject();
    }

    public int GetObjectIndex(MonoBehaviour obj)
    {
        for (int i = 0; i < _SpawnedList.Count; i++)
        {
            if (_SpawnedList[i] == obj)
                return i;
        }

        return -1;
    }

    private void SpawnObject()
    {
        T spawned;
        spawned = UnityEngine.Object.Instantiate(_prefab, _startPrefabPosition, _prefabRotation, _prefabContainer);
        spawned.gameObject.SetActive(false);
        _SpawnedList.Add(spawned);
    }
}
