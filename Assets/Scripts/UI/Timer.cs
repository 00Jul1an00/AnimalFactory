using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Slider _timerSlider;
    private readonly int _smoothleness = 30;

    private void Start()
    {
        _timerSlider = GetComponent<Slider>();
        UpdateValueOnTimer(0);
    }

    public void UpdateValueOnTimer(float value)
    {
        _timerSlider.normalizedValue = value;
    }

    public IEnumerator TimerAnimation(float duration)
    {
        float t = 0; 
        float min = duration / _smoothleness;
        float max = duration;
        float normalizeValue = min / max;

        for (int i = 0; i < _smoothleness; i++)
        {   
            t += normalizeValue;
            UpdateValueOnTimer(t);
            yield return new WaitForSeconds(duration / _smoothleness);
        }

        UpdateValueOnTimer(0);
    }
}
