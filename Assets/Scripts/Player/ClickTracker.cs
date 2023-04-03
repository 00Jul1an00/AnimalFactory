using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickTracker : MonoBehaviour, IPointerClickHandler
{
    public event Action Clicked;
    public int ClickCount { get; private set; }
    public void ClickReset() => ClickCount = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        ClickCount++;
        Clicked?.Invoke();
    }
}
