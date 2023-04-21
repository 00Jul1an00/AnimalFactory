using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class AnimalsData : MonoBehaviour
{
    [SerializeField] private List<AnimalSO> _baseAnimals;

    public static AnimalsData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _baseAnimals = _baseAnimals.OrderBy(x => x.ID).ToList();
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public AnimalSO GetAnimalByID(int id)
    {
        var animalToReturn = _baseAnimals.Find(x => x.ID == id);

        if (animalToReturn == null)
            throw new Exception("ID Does not Exist");
        else
            return animalToReturn;
    }
}
