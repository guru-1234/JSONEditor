using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchMonitor : MonoBehaviour
{
    public List<TMP_Dropdown> listOfSwitches;
    public Switch _switch;
    private void Awake()
    {
        
    }

    public void StatusChanged()
    {
        //Trigger to Switch 
        List<SwitchStatus> switchCondition = new List<SwitchStatus>();
        
        foreach(var dropDown in listOfSwitches)
        {
            SwitchStatus sw = ValueToStatus.GetStatus(dropDown.value);
            switchCondition.Add(sw);
        }


        _switch.CheckSwitchCondition(switchCondition);
    }
}


public static class ValueToStatus
{
    public static SwitchStatus GetStatus(int val)
    {
        switch (val)
        {
            case 0:
                return SwitchStatus.None;
            case 1:
                return SwitchStatus.Open;
            case 2:
                return SwitchStatus.Close;
            case 3:
                return SwitchStatus.Ignored;
            default: return SwitchStatus.None;
        }
    }
}
