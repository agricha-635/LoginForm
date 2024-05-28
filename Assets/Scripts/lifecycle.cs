using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifecycle : MonoBehaviour
{
    // Start is called before the first frame update




    // Update is called once per frame
    void Update()
    {

    }
    void Start()
    {
        Debug.Log("start");
    }
    private void Awake()
    {
        Debug.Log("Awake");
    }
}
