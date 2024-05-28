using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollectData : MonoBehaviour
{
    private UserForm userForm;
    private void Start()
    {
        // Get reference to UserForm script
        userForm = FindObjectOfType<UserForm>();
    }
    public void GoToScene2()
    {
        // DontDestroyOnLoad(gameObject);
        string dataToKeep = userForm.messageField.text;
        StaticData.ValueToKeep = dataToKeep;
        SceneManager.LoadSceneAsync(1);
    }

}
