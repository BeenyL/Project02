﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    //TODO build a more strutured connection
    public static ITargetable CurrentTarget;

    //interefaces don't serialize, so need class reference
    [SerializeField] Creature _objectToTarget = null;

    private void Update()
    {
        //target the object when '1' is pressed
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            // target the object, if it is targetable
            ITargetable possibleTarget = _objectToTarget.GetComponent<ITargetable>();
            if(possibleTarget != null)
            {
                Debug.Log("new target acquired!");
                CurrentTarget = possibleTarget;
                _objectToTarget.Target();
            }
        }
    }
}
