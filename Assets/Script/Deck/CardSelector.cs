using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class CardSelector : MonoBehaviour
{
    [SerializeField] Transform SelectedCardSlotPos;
    [SerializeField] Image enemySelector;
    [SerializeField] Button cancel;
    [SerializeField] Button confirm;
    [SerializeField] Text notify;
    [SerializeField] PlayerHUD playerhud;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip SelectCard;
    [SerializeField] AudioClip CancelCard;
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
                    audio.PlayOneShot(SelectCard);
                    //playerhandslot.transform.position = gameManager.selectedCardPos.position;
                    playerhandslot.transform.DOMove(gameManager.selectedCardPos.position, .5f, false);
                    playerhandslot.transform.DORotate(new Vector3(0, 360, 0), .5f, RotateMode.FastBeyond360);
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
        //SelectedCardSlotPos.position = gameManager.cardPosTransforms[playerhandslot._slot].position;
        audio.PlayOneShot(CancelCard);
        playerhandslot.transform.DOMove(gameManager.cardPosTransforms[playerhandslot._slot].position, 1f, false);
        playerhandslot.transform.DORotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360);
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
                audio.PlayOneShot(abilityCard.sound);
                playerprop._mana -= card.Cost;
                playerhandslot.transform.parent = gameManager.discardTransform;
                gameManager.DiscardDeck.Add(card);
                StartCoroutine(ActivateAnimation());
                gameManager.Hand.DeletefromHand(playerhandslot._slot);

                gameManager.FrontEndDiscardDeck.Add(gameManager.HandDeck[playerhandslot._slot]);
                gameManager.HandDeck[playerhandslot._slot] = null;

                cancel.gameObject.SetActive(false);
                confirm.gameObject.SetActive(false);
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
    }

    IEnumerator ActivateAnimation()
    {
        PlayerHandSlot playerhandslot = SelectedCardSlotPos.gameObject.GetComponent<PlayerHandSlot>();
        playerhandslot.transform.DOScale(.01f, .25f);
        yield return new WaitForSeconds(1f);
        playerhandslot.transform.DOScale(1f, .25f);
        playerhandslot.transform.position = gameManager.discardTransform.position;
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

