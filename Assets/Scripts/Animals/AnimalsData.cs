using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class AnimalsData : MonoBehaviour
{
    [SerializeField] private List<AnimalSO> _animals;

    public static AnimalsData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _animals = _animals.OrderBy(x => x.Id).ToList();
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public AnimalSO GetAnimalByID(int id)
    {
        var animalToReturn = _animals.Find(x => x.Id == id);

        if (animalToReturn == null)
            throw new Exception("ID Does not Exist");
        else
            return animalToReturn;
    }
}
