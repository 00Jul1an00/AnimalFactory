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
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            _baseAnimals = _baseAnimals.OrderBy(x => x.ID).ToList();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AnimalSO GetAnimalByID(int id)
    {
        var animalToReturn = _baseAnimals.Find(x => x.ID == id);

        if (animalToReturn == null)
            throw new Exception("ID Does not Exist");
        else
            return animalToReturn;
    }

    public AnimalSO GetRandAnimalByQuality(AnimalQuality quality)
    {
        var animalsByQuality = _baseAnimals.Where(a => a.Quility == quality).ToArray();
        int rand = UnityEngine.Random.Range(0, animalsByQuality.Length - 1);
        return animalsByQuality[rand];
    }
}
