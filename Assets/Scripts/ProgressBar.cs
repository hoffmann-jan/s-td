using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public Text displayText;

    private float currentValue = 0f;

    private UnityEvent OnProgressComplete;

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if (value >= slider.maxValue)
            {
                OnProgressComplete.Invoke();
            }

            currentValue = value % slider.maxValue;
            slider.value = currentValue;
            displayText.text = (slider.value * 100).ToString("0.00") + "%";
        }
    }










    // Start is called before the first frame update
    void Start()
    {
        CurrentValue = 0f;

        // Initialize onProgressComplete and set a basic callback
        if (OnProgressComplete == null)
        {
            OnProgressComplete = new UnityEvent();
        }
        OnProgressComplete.AddListener(ProgressComplete);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentValue += 0.0153f;
    }

    
    // The method to call when the progress bar fills up
    void ProgressComplete()
    {
        Debug.Log("Progress Complete");
    }
}
