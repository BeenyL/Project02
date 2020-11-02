using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSelector : MonoBehaviour
{
    [SerializeField] Transform SelectedCardSlotPos;
    [SerializeField] Button cancel;
    [SerializeField] Button confirm;
    [SerializeField] PlayerHUD playerhud;
    // normal raycasts do not work on UI elements, they require a special kind
    GraphicRaycaster _raycaster;
    PointerEventData _pointerEventData;
    EventSystem _eventSystem;
    GameManager gameManger;
    PlayerProperty playerprop;
    private void Awake()
    {
        _raycaster = GetComponent<GraphicRaycaster>();
        _eventSystem = GetComponent<EventSystem>();
        gameManger = FindObjectOfType<GameManager>();
        playerprop = FindObjectOfType<PlayerProperty>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bool choseCard = false;
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
                    PlayerHandSlot playerhandslot = result.gameObject.GetComponentInParent<PlayerHandSlot>();
                    SelectedCardSlotPos = playerhandslot.transform;
                    playerhandslot.transform.position = gameManger.selectedCardPos.position;
                    choseCard = true;
                }
                break;
            }
            if(choseCard == true) {
                cancel.gameObject.SetActive(true);
                confirm.gameObject.SetActive(true);
            }
        }
    }
    public void previousCardPos()
    {
        PlayerHandSlot playerhandslot = SelectedCardSlotPos.gameObject.GetComponent<PlayerHandSlot>();
        SelectedCardSlotPos.position = gameManger.cardPosTransforms[playerhandslot._slot].position;
        cancel.gameObject.SetActive(false);
        confirm.gameObject.SetActive(false);
    }

    public void playCardEffect()
    {
        PlayerHandSlot playerhandslot = SelectedCardSlotPos.gameObject.GetComponent<PlayerHandSlot>();
        if (playerprop._mana >= gameManger.Hand.GetCard(playerhandslot._slot).Cost)
        {
            playerprop._mana -= gameManger.Hand.GetCard(playerhandslot._slot).Cost;
            gameManger.Hand.GetCard(playerhandslot._slot).Play();
        }
        else
        {
            Debug.Log("player mana " + playerprop._mana);
            Debug.Log("card mana: " + gameManger.Hand.GetCard(playerhandslot._slot).Cost);
            Debug.Log("card name: " + gameManger.Hand.GetCard(playerhandslot._slot).Name);
            Debug.Log("fail to play");
        }
        playerhud.updateManaBar();
        cancel.gameObject.SetActive(false);
        confirm.gameObject.SetActive(false);
    }

}

