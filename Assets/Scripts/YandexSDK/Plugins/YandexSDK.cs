using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();


    private bool _isClicked;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L) && !_isClicked)
        {
            Hello();
            _isClicked = true;
        }
    }
}
