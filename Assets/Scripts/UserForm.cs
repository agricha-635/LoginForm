using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserForm : MonoBehaviour
{
    Scene scene;
    private AgeSlider ageSlider;
    //Register Panel
    [SerializeField] private GameObject RegisterPanel;
    //HomePanel Class
    public GameObject HomePanel;
    //LoginPanel
    [SerializeField] private GameObject LoginPanel;

    public GameObject ResetPassPanel;
    //Register Form Info
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_InputField emailRegisteredField;
    [SerializeField] private TMP_InputField passwordRegisteredField;
    [SerializeField] private TMP_Dropdown genderField;
    [SerializeField] private Toggle agreeToggle;


    //MessageBox in RegisterFormPanel
    public TMP_Text messageText;

    //Login Info
    [SerializeField] private TMP_InputField emailLoginField;
    [SerializeField] private TMP_InputField passwordLoginField;
    //MessageBox in LoginFormPanel
    [SerializeField] private TMP_Text messageLoginText;

    //Home Info
    //MessageBox in HomePanel
    public TMP_Text messageField;


    //taking registered value to print
    public string user_Name;
    public string userEmail;
    public string userPass;
    public string selectedGender;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("Scene Index: " + scene.buildIndex);
        Debug.Log("Scene Name: " + scene.name);
        Debug.Log("Scene Path: " + scene.path);

        agreeToggle.isOn = false;

        ageSlider = FindObjectOfType<AgeSlider>();
    }

    public bool IsEmailValid(string email)
    {
        // Check if email is empty
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        bool hasAtSign = false;
        bool hasDot = false;

        // Iterate through each character in the email
        foreach (char c in email)
        {
            // Check if character is '@'
            if (c == '@')
            {
                hasAtSign = true;
            }
            // Check if character is '.'
            else if (c == '.')
            {
                hasDot = true;
            }
        }

        // Check if email contains '@' and '.'
        return hasAtSign && hasDot;
    }

    public bool IsPasswordValid(string password)
    {
        // Check if password is between 8 and 15 characters long
        if (password.Length < 8 || password.Length > 15)
        {
            return false;
        }

        bool hasLowerCase = false;
        bool hasUpperCase = false;
        bool hasDigit = false;
        bool hasSpecialChar = false;

        // Iterate through each character in the password
        foreach (char c in password)
        {
            // Check if character is a lowercase letter
            if (char.IsLower(c))
            {
                hasLowerCase = true;
            }
            // Check if character is an uppercase letter
            else if (char.IsUpper(c))
            {
                hasUpperCase = true;
            }
            // Check if character is a digit
            else if (char.IsDigit(c))
            {
                hasDigit = true;
            }
            // Check if character is a special character (not a letter or digit)
            else if (!char.IsLetterOrDigit(c))
            {
                hasSpecialChar = true;
            }
        }

        // Check if password meets all criteria
        return hasLowerCase && hasUpperCase && hasDigit && hasSpecialChar;
    }


    public void OnRegisterBtnClick()
    {
        string name = userName.text;
        string email = emailRegisteredField.text;
        string password = passwordRegisteredField.text;

        string message = RegisterOnforCheck(email, password, name);

        if (string.IsNullOrEmpty(message))
        {
            if (IsEmailValid(email) && IsPasswordValid(password) && !string.IsNullOrEmpty(selectedGender) && (agreeToggle.isOn == true))
            {
                Debug.Log("Registered Successfully.");
                LoginPanel.SetActive(true);
                RegisterPanel.SetActive(false);
                HomePanel.SetActive(false);

                userEmail = email;
                userPass = password;
                user_Name = name;
            }
            else if (!IsEmailValid(email))
            {
                messageText.text = "Please Enter valid Email.";
            }
            else if (!IsPasswordValid(password))
            {
                messageText.text = "Please Enter valid Password.";
            }
            else if (string.IsNullOrEmpty(selectedGender))
            {
                messageText.text = "Please Select a Gender.";
            }
            else if (agreeToggle.isOn == false)
            {
                messageText.text = "Please verify that all informations are correct.";
            }
            else
            {
                messageText.text = "Please Enter valid email, password, and gender.";
            }
        }
        else
        {
            Debug.LogError("Error:" + message);
        }
    }


    public void OnLoginBtnClick()
    {
        string email = emailLoginField.text;
        string password = passwordLoginField.text;
        string name = userName.text;

        string message2 = LoginOnforCheck(email, password);

        if (string.IsNullOrEmpty(message2))
        {
            if (email == userEmail && password == userPass)
            {
                Debug.Log("Login Successfully");
                HomePanel.SetActive(true);
                messageField.text = $"Name: {name} <br> Email: {email} <br> Password: {password} <br> Gender: {selectedGender} <br> Age: {AgeSlider.selectedAge}";
                RegisterPanel.SetActive(false);
                LoginPanel.SetActive(false);
            }
            else if (email != userEmail)
            {
                messageLoginText.text = "Please Enter Registered Email.";
            }
            else if (password != userPass)
            {
                messageLoginText.text = "Please Enter Correct Password.";
            }
        }
        else
        {
            Debug.LogError(message2);
        }
    }

    private void ResetFormFields()
    {
        // Reset all form fields to their initial state
        userName.text = "";
        emailRegisteredField.text = "";
        passwordRegisteredField.text = "";
        emailLoginField.text = "";
        passwordLoginField.text = "";
        genderField.value = 0;
        agreeToggle.isOn = false;

        // Reset user data variables
        user_Name = "";
        userEmail = "";
        userPass = "";
        selectedGender = "";
    }

    public void OnBackButtonClick()
    {
        HomePanel.SetActive(false);
        RegisterPanel.SetActive(true);
        LoginPanel.SetActive(false);

        // Reset the form fields
        ResetFormFields();
        ageSlider.ResetAge();
    }


    private string RegisterOnforCheck(string name, string email, string password)
    {
        string returnString = "";

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            returnString = "Please Enter your Information.";
            messageText.text = "Please Enter your Information.";
        }
        else
        {
            returnString = "";
        }
        return returnString;
    }

    private string LoginOnforCheck(string email, string password)
    {
        string returnString = "";

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            returnString = "Please Enter your Information.";
            messageLoginText.text = "Please Enter your Email and Password.";
        }
        else
        {
            returnString = "";
        }
        return returnString;
    }

    public void OnGenderDropdownValueChanged()
    {
        selectedGender = genderField.options[genderField.value].text;
    }

    public void OnClickResetPasswordButton()
    {
        ResetPassPanel.SetActive(true);
        HomePanel.SetActive(false);
    }

}