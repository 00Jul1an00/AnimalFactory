using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T _prefab;
    private int _spawnCount;
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
        _spawnCount = spawnCount;
        _isDynamic = isDynamic;
        _spawnedList = new List<T>(_spawnCount);
        SpawnedList = _spawnedList;
    }

    public void Init(Vector3 position, Quaternion rotation, Transform container)
    {
        _startPrefabPosition = position;
        _prefabRotation = rotation;
        _prefabContainer = container;

        for (int i = 0; i < _spawnCount; i++)
            SpawnObject();
    }

    public void ActivateObject(int activateCount = 1)
    {
        if (activateCount > _spawnedList.Count)
            return;

        for (int i = 0; i < activateCount; i++)
        {
            _spawnedList[LastActiveIndex++].gameObject.SetActive(true);

            if(LastActiveIndex >= _spawnedList.Count && _isDynamic)
            {
                Debug.Log("Object Pool capacity was increased");
                IncreasePoolCapacity();
            }
            else if (LastActiveIndex >= _spawnedList.Count)
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

    public void ActivateConcreateObject(T obj)
    {
        _spawnedList[GetObjectIndex(obj)].gameObject.SetActive(true);
    }

    public void DeactivateObject(T obj)
    {
        _spawnedList[GetObjectIndex(obj)].gameObject.SetActive(false);
        obj.gameObject.transform.position = _startPrefabPosition;
    }

    public T GetObjectFromPool(int index)
    {
        if (index <= -1 || index >= _spawnedList.Count - 1)
            throw new Exception("List doesnt have Object at this index");

        return _spawnedList[index];
    }

    public T GetLastActivatedObject()
    {
        if (LastActiveIndex == 0)
            return _spawnedList[_spawnCount - 1];

        return _spawnedList[LastActiveIndex - 1];
    }

    private void IncreasePoolCapacity()
    {
        _spawnCount *= 2;

        for(int i = _spawnedList.Capacity; i < _spawnCount; i++)
            SpawnObject();
    }

    public int GetObjectIndex(T obj)
    {
        //for (int i = 0; i < _spawnedList.Count - 1; i++)
        //{
        //    if (_spawnedList[i].Equals(obj))
        //        return i;
        //}

        //return -1;

        return _spawnedList.IndexOf(obj);
    }

    public void ClearPool()
    {
        foreach (T obj in _spawnedList)
            UnityEngine.Object.Destroy(obj);
    }

    public void ChangeSpawnList(List<T> newSpawnList)
    {
        if(newSpawnList.Capacity > _spawnCount)
            newSpawnList.Capacity = _spawnCount;

        int newListCapacity = 0;

        for(int i = 0; i < _spawnedList.Count; i++)
        {
            if (newSpawnList[i] == null)
                return;

            newListCapacity++;
            newSpawnList[i].transform.SetParent(_prefabContainer);
            newSpawnList[i].transform.position = _startPrefabPosition;
            newSpawnList[i].enabled = _spawnedList[i].enabled;
            _spawnedList[i] = newSpawnList[i];
        }

        for(int i = 0; i < _spawnCount - newListCapacity; i++)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        T spawned;
        spawned = UnityEngine.Object.Instantiate(_prefab, _startPrefabPosition, _prefabRotation, _prefabContainer);
        spawned.gameObject.SetActive(false);
        _spawnedList.Add(spawned);
    }
}
