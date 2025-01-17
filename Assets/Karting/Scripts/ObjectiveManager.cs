﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    List<Objective> m_Objectives = new List<Objective>();
    List<Objective> m_Objectives2 = new List<Objective>();

    public List<Objective> Objectives => m_Objectives;
    public List<Objective> Objectives2 => m_Objectives2;
    
    public static Action<Objective> RegisterObjective;
    public static Action<Objective> RegisterObjective2;

    public void OnEnable()
    {
        RegisterObjective += OnRegisterObjective;
    }

    public bool AreAllObjectivesCompleted()
    {
        if (m_Objectives.Count == 0)
            return false;

        for (int i = 0; i < m_Objectives.Count; i++)
        {
            // pass every objectives to check if they have been completed
            if (m_Objectives[i].isBlocking())
            {
                // break the loop as soon as we find one uncompleted objective
                return false;
            }
        }

        // found no uncompleted objective
        return true;
    }

    public bool AreAllObjectivesCompleted2()
    {
        if (m_Objectives2.Count == 0)
            return false;

        for (int i = 0; i < m_Objectives2.Count; i++)
        {
            // pass every objectives to check if they have been completed
            if (m_Objectives2[i].isBlocking())
            {
                // break the loop as soon as we find one uncompleted objective
                return false;
            }
        }

        // found no uncompleted objective
        return true;
    }

    public void OnRegisterObjective(Objective objective)
    {
        m_Objectives.Add(objective);
    }
    
    public void OnRegisterObjective2(Objective objective)
    {
        m_Objectives2.Add(objective);
    }
}