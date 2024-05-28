using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransferData : MonoBehaviour
{
    [SerializeField] private TMP_Text messageBox;

    private void Start()
    {
        string newMsg = StaticData.ValueToKeep;
        messageBox.text = newMsg;
    }
}
