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
        SaveLoadSystem.Instance.SaveClicksCount(ClickCount);
        Clicked?.Invoke();
    }

    private void Awake()
    {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ClickCount = SaveLoadSystem.Instance.LoadClicksCount();
    }
}
