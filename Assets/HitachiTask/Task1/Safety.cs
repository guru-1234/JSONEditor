using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safety : MonoBehaviour
{
    public GameObject SafeButton;
    public GameObject NotSafeButton;

    public void EnablingSafety(bool status)
    {
        if(status)
        {
            SafeButton.SetActive(true);
            NotSafeButton.SetActive(false);
        }
        else
        {
            SafeButton.SetActive(false);
            NotSafeButton.SetActive(true);
        }
    }
}
