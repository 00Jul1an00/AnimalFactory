using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Slider _timerSlider;
    
    private const int DURATION_SPLITING = 50;

    public float AnimationDuration { get { return AnimationDuration; } set { AnimationDuration = value; } }

    private void Start()
    {
        _timerSlider = GetComponent<Slider>();
        UpdateValueOnTimer(0);
    }

    public void UpdateValueOnTimer(float value)
    {
        _timerSlider.normalizedValue = value;
    }

    public IEnumerator FixedTimerAnimation(float duration)
    {
        float t = 0;
        float min = duration / DURATION_SPLITING;
        float max = duration;
        float normalizeValue = min / max;

        for (int i = 0; i < DURATION_SPLITING; i++)
        {     
            t += normalizeValue;
            UpdateValueOnTimer(t);
            yield return new WaitForSeconds(duration / DURATION_SPLITING);
        }

        UpdateValueOnTimer(0);
    }
}
