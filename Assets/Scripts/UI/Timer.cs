using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Slider _timerSlider;
    
    public const int DURATION_SPLITING = 50;

    public float AnimationDuration { get; set; }

    private void Start()
    {
        _timerSlider = GetComponent<Slider>();
        UpdateValueOnTimer(0);
    }

    public void UpdateValueOnTimer(float value)
    {
        _timerSlider.normalizedValue = value;
    }

    public IEnumerator TimerAnimation()
    {
        float t = 0;
        float normalizeValue = CalcNormolizeValue(AnimationDuration);

        for (int i = 0; i < DURATION_SPLITING; i++)
        {
            
            t += normalizeValue;
            UpdateValueOnTimer(t);
            yield return new WaitForSeconds(AnimationDuration / DURATION_SPLITING);
        }

        UpdateValueOnTimer(0);
    }

    private float CalcNormolizeValue(float value)
    {
        float min = value / DURATION_SPLITING;
        float max = value;
        return min / max;
    }
}
