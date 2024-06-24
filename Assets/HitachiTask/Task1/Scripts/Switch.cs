using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SwitchStatus
{
    None,
    Open,
    Close,
    Ignored
    
}
public class Switch : MonoBehaviour
{
    public List<SwitchStatus> switchCondition;
    public Safety safetyPanel;
    SwitchController controller;
    public delegate void SwitchControllerDelegate(bool status);

    public event SwitchControllerDelegate OnSafety;
    public event SwitchControllerDelegate OnNotSafety;
    private void Awake()
    {
        controller = FindObjectOfType<SwitchController>();
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
       
    }

   

    

    public void CheckSwitchCondition(List<SwitchStatus> switchStatus)
    {
        int checkedReqSwitches = -1;
        //Debug.Log(switchStatus.Count);
        //Debug.Log(switchCondition.Count);
        if (switchStatus.Count==switchCondition.Count)
        {
            for(var i=0;i<switchStatus.Count;i++)
            {
                if (switchCondition[i] == switchStatus[i])
                {
                    checkedReqSwitches++;

                }
            }

            if(checkedReqSwitches>= switchCondition.Count-1)
            {
                //trigger safety
                safetyPanel.EnablingSafety(true);


            }
            else
            {
                //trigger Not safety
                safetyPanel.EnablingSafety(false);

            }

        }
        else
        {
            Debug.Log("Condition doesnt match with status");
        }

    }
}
