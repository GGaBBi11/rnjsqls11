﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachinManager : MonoBehaviour
{
    PlayerStateMachine[] playerStateMachines;
    KeyCode keyInput;

    private void Awake()
    {
        playerStateMachines = GetComponents<PlayerStateMachine>();
    }

    private void Update()
    {
        CompareKeyInput();
    }
    private void CompareKeyInput()
    {
        foreach (var machine in playerStateMachines)
        {
            if (keyInput == machine.keyCode)
            {
                if (machine.IsExeuteOk())
                {
                    machine.Execute();

                }
                keyInput = KeyCode.None;
                break;
            }
        }
    }

    private void MachineWorkflow()
    {
/*        if (currentMachine != null)
            currentMachine.UpdateState();*/
    }


    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && e.keyCode != KeyCode.None)
        {
            keyInput = e.keyCode;
        }
    }




}
