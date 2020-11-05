using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSelector : MonoBehaviour
{
    [SerializeField] Transform SelectedCardSlotPos;
    [SerializeField] Image enemySelector;
    [SerializeField] Button cancel;
    [SerializeField] Button confirm;
    [SerializeField] Text notify;
    [SerializeField] PlayerHUD playerhud;
    // normal raycasts do not work on UI elements, they require a special kind
    GraphicRaycaster _raycaster;
    PointerEventData _pointerEventData;
    EventSystem _eventSystem;
    GameManager gameManager;
    PlayerProperty playerprop;
    private void Awake()
    {
        _raycaster = GetComponent<GraphicRaycaster>();
        _eventSystem = GetComponent<EventSystem>();
        gameManager = FindObjectOfType<GameManager>();
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
                    playerhandslot.transform.position = gameManager.selectedCardPos.position;
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
        SelectedCardSlotPos.position = gameManager.cardPosTransforms[playerhandslot._slot].position;
        cancel.gameObject.SetActive(false);
        confirm.gameObject.SetActive(false);
    }

    public void playCardEffect()
    {
        PlayerHandSlot playerhandslot = SelectedCardSlotPos.gameObject.GetComponent<PlayerHandSlot>();
        AbilityCard abilityCard = (AbilityCard)gameManager.Hand.GetCard(playerhandslot._slot);
        if (playerprop._mana >= gameManager.Hand.GetCard(playerhandslot._slot).Cost)
        {
            if (abilityCard.effect.ToString() == "DMG" && enemySelector.IsActive() == false)
            {
                CheckIfDmgCard();
            }
            else
            {
                Card card = gameManager.Hand.GetCard(playerhandslot._slot);
                card.Play();
                playerprop._mana -= card.Cost;
                playerhandslot.transform.parent = gameManager.discardTransform;
                gameManager.DiscardDeck.Add(card);
                playerhandslot.transform.position = gameManager.discardTransform.position;
                gameManager.Hand.DeletefromHand(playerhandslot._slot);

                gameManager.FrontEndDiscardDeck.Add(gameManager.HandDeck[playerhandslot._slot]);
                gameManager.HandDeck[playerhandslot._slot] = null;
            }
        }
        else
        {
            if (playerprop._mana < gameManager.Hand.GetCard(playerhandslot._slot).Cost)
            {
                notify.text = "Not Enough Mana!";
            }
            Debug.Log("player mana " + playerprop._mana);
            Debug.Log("card mana: " + gameManager.Hand.GetCard(playerhandslot._slot).Cost);
            Debug.Log("card name: " + gameManager.Hand.GetCard(playerhandslot._slot).Name);
            Debug.Log("fail to play");
        }
        StartCoroutine(StartNotify());
        playerhud.updateManaBar();
        cancel.gameObject.SetActive(false);
        confirm.gameObject.SetActive(false);
    }

    public void CheckIfDmgCard()
    {
        PlayerHandSlot playerhandslot = SelectedCardSlotPos.gameObject.GetComponent<PlayerHandSlot>();
        AbilityCard abilityCard = (AbilityCard)gameManager.Hand.GetCard(playerhandslot._slot);
        if (abilityCard.effect.ToString() == "DMG" && playerprop._mana >= gameManager.Hand.GetCard(playerhandslot._slot).Cost &&
            enemySelector.IsActive() == false)
        {
            notify.text = "Please Select a Target!";
        }
        else
        {
            notify.text = "";
        }
        StartCoroutine(StartNotify());
    }

    IEnumerator StartNotify()
    {
        notify.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        notify.gameObject.SetActive(false);
    }

}

