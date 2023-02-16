using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T _prefab;
    private int _SpawnCount;
    private List<T> _SpawnedList = new();
    private Vector3 _startPrefabPosition;

    public int LastActiveIndex { get; private set; }

    public ObjectPool(T prefab, int spawnCount)
    {
        _prefab = prefab;
        _SpawnCount = spawnCount;
    }

    public void Init(Vector3 position, Quaternion rotation, Transform container)
    {
        _startPrefabPosition = position;

        for (int i = 0; i < _SpawnCount; i++)
        {
            T spawned;
            spawned = Object.Instantiate(_prefab, position, rotation, container);
            spawned.gameObject.SetActive(false);
            _SpawnedList.Add(spawned);
        }
    }

    public void ActivateObject(int activateCount = 1)
    {
        for (int i = 0; i < activateCount; i++)
        {
            if (LastActiveIndex >= _SpawnCount)
            {
                Debug.Log("all objects in pull are active"); 
                LastActiveIndex = 0;
            }

            _SpawnedList[LastActiveIndex++].gameObject.SetActive(true);
        }
    }

    //?
    public void DeactivateObject(int deactivateCount = 1)
    {
        for (int i = 0; i < deactivateCount; i++)
        {        
            T obj = _SpawnedList[i];
            obj.gameObject.SetActive(false);
            obj.transform.position = _startPrefabPosition;

            LastActiveIndex--;

            if (LastActiveIndex <= 0)
                LastActiveIndex = 0;
        }
    }
    public T GetObjectFromPool(int index)
    {
        if(index <= -1)
            return null;

        return _SpawnedList[index];
    }

    private void IncreasePoolCapacity()
    {

    }
}
