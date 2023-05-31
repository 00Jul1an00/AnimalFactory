using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    public static YandexSDK Instance { get; private set; }

    [DllImport("__Internal")]
    private static extern void Hello();


    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private bool _isClicked;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L) && !_isClicked)
        {
            Hello();
            _isClicked = true;
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
        }
    }
    [SerializeField] private AnimalSO _so;
}
