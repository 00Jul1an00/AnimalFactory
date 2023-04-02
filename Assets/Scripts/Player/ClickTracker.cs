using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickTracker : MonoBehaviour, IPointerClickHandler
{
    public int ClickCount { get; private set; }
    public void ClickReset() => ClickCount = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        ClickCount++;
        print(ClickCount + "From CT");
    }
}
