﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemySelector : MonoBehaviour
{
    GraphicRaycaster _raycaster;
    PointerEventData _pointerEventData;
    EventSystem _eventSystem;
    GameManager gameManger;
    private void Awake()
    {
        _raycaster = GetComponent<GraphicRaycaster>();
        _eventSystem = GetComponent<EventSystem>();
        gameManger = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // set up new Pointer Event
            _pointerEventData = new PointerEventData(_eventSystem);
            _pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            // raycast using the graphics raycaster and mouse click position
            _raycaster.Raycast(_pointerEventData, results);
            // if a card is selected -> takes player to upgrade panel

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponentInParent<PlayerHandSlot>() != null)
                {

                }
                break;
            }
        }
    }
}
