using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AgeSlider : MonoBehaviour
{
    [SerializeField] private Slider ageSlider;
    [SerializeField] private TMP_InputField ageInputField;

    public static string selectedAge;
    private void Start()
    {
        // Set the minimum and maximum values of the slider to 18 and 35 respectively
        ageSlider.minValue = 18;
        ageSlider.maxValue = 35;

        ResetAge();

        // Add a listener to the slider to update the input field when the slider value changes
        ageSlider.onValueChanged.AddListener(delegate { UpdateInputField(); });

        // Add a listener to the input field to update the slider when the input field value changes
        ageInputField.onValueChanged.AddListener(delegate { UpdateSlider(); });
    }

    private void UpdateInputField()
    {
        // Update the input field text with the value of the slider
        ageInputField.text = ageSlider.value.ToString();

        selectedAge = ageInputField.text;
    }

    private void UpdateSlider()
    {
        // Parse the input field text as an integer and set the value of the slider
        int age;
        if (int.TryParse(ageInputField.text, out age))
        {

            ageSlider.value = Mathf.Clamp(age, ageSlider.minValue, ageSlider.maxValue);
        }
    }

    public void ResetAge()
    {
        // Set the value of the slider to 18 and the value of the input field to "18"
        ageSlider.value = 18;
        ageInputField.text = "18";

        // Update the selectedAge variable
        selectedAge = ageInputField.text;
    }
}
