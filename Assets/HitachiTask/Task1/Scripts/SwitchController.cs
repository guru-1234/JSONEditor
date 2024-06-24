using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public List<Switch> AllSwitches;
    private void Awake()
    {
        Switch[] sw = FindObjectsOfType<Switch>();
        AllSwitches = sw.ToList();
        Subscribeevents();
    }

    private void Subscribeevents()
    {
        foreach (Switch sw in AllSwitches)
        {
            sw.OnSafety += Switch_Safety;
            sw.OnNotSafety += Switch_NotSafety;
        }
    }

    private void Switch_NotSafety(bool status)
    {
       
    }

    private void Switch_Safety(bool status)
    {
       
    }
}
