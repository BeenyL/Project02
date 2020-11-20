using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemySelector : MonoBehaviour
{
    [SerializeField] Image selectedEnemyImg;
    [SerializeField] Image allSelectedEnemyImg;
    [SerializeField] CardSelector cardselector;
    Enemy enemy;
    public Enemy _enemy => enemy;

    bool enemychose = false;
    public bool _enemychose { get => enemychose; set => enemychose = value; }
    GraphicRaycaster _raycaster;
    PointerEventData _pointerEventData;
    EventSystem _eventSystem;
    GameManager gameManger;
    private void Awake()
    {
        _raycaster = GetComponent<GraphicRaycaster>();
        _eventSystem = GetComponent<EventSystem>();
        gameManger = FindObjectOfType<GameManager>();
        cardselector = GetComponent<CardSelector>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            enemychose = false;

            _pointerEventData = new PointerEventData(_eventSystem);
            _pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            _raycaster.Raycast(_pointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponentInParent<EnemySlot>() != null)
                {
                    EnemySlot enemyslot = result.gameObject.GetComponentInParent<EnemySlot>();
                    selectedEnemyImg.transform.position = enemyslot.transform.position;
                    enemychose = true;
                    enemy = enemyslot.GetComponent<Enemy>();
                }
                break;
            }
            if(enemychose == true)
            {
                selectedEnemyImg.gameObject.SetActive(true);
                if (cardselector._aoeCard == true)
                {
                    allSelectedEnemyImg.gameObject.SetActive(true);
                }
                else
                {
                    allSelectedEnemyImg.gameObject.SetActive(false);
                }
            }
        }
    }

    public void aoeSelect()
    {
        if(selectedEnemyImg.IsActive() == true) { 
        allSelectedEnemyImg.gameObject.SetActive(true);
        }
    }

    public void defSelect()
    {
            allSelectedEnemyImg.gameObject.SetActive(false);
    }

}
