using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "AnimalSO", menuName = "Scriptable Objects/Animal")]
public class AnimalSO : ScriptableObject
{
    [SerializeField] private AnimalQuality _animalQuality;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;
    [SerializeField] private int _id;

    private AnimalQualitySO _quality;

    public AnimalQualitySO Quality => _quality;
    public Sprite Sprite => _sprite;
    public int ID => _id;

    private void OnValidate()
    {
        string path = _animalQuality.ToString();
        _quality = Resources.Load<AnimalQualitySO>("AnimalQuality/" + path);
    }
}
