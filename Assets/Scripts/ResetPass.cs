using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetPass : MonoBehaviour
{
    private UserForm userForm;
    private AgeSlider ageSlider;
    [SerializeField] private TMP_InputField OldPassword;
    [SerializeField] private TMP_InputField NewPassword;
    [SerializeField] private TMP_InputField ConfirmPassword;

    public TMP_Text messageText;
    private void Start()
    {
        // Get reference to UserForm script
        userForm = FindObjectOfType<UserForm>();
    }

    public void OnSubmitBtnClick()
    {
        string oldPass = OldPassword.text;
        string newPass = NewPassword.text;
        string confirmPass = ConfirmPassword.text;

        // Check if all fields are filled
        if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
        {
            messageText.text = "Please fill in all fields.";
            return;
        }

        // Check if old password matches the current password
        if (oldPass != userForm.userPass)
        {
            messageText.text = "Old password is incorrect.";
            return;
        }

        if (newPass == oldPass)
        {
            messageText.text = "New Password should be different";
            return;
        }
        // Check if new password is valid
        if (!userForm.IsPasswordValid(newPass))
        {
            messageText.text = "Please enter a valid new password.";
            return;
        }

        // Check if new password matches confirm password
        if (newPass != confirmPass)
        {
            messageText.text = "New password and confirm password do not match.";
            return;
        }

        // Update user password
        userForm.userPass = newPass;
        userForm.HomePanel.SetActive(true);
        userForm.ResetPassPanel.SetActive(false);
        userForm.messageField.text = $"Name: {userForm.user_Name} <br> Email: {userForm.userEmail} <br> Password: {userForm.userPass}<br> Gender: {userForm.selectedGender} <br> Age: {AgeSlider.selectedAge}";
    }

}
