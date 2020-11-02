using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCardView : MonoBehaviour
{
    [SerializeField] Text _nameTextUI = null;
    [SerializeField] Text _costTextUI = null;
    [SerializeField] Text _typeText = null;
    [SerializeField] Image _graphicUI = null;
    [SerializeField] Text _backcostText = null;
    [SerializeField] Text _backnameText = null;
    [SerializeField] Text _backypeText = null;
    public void Display(AbilityCard abilityCard)
    {
        _nameTextUI.text = abilityCard.Name;
        _backnameText.text = abilityCard.Name;
        _costTextUI.text = abilityCard.Cost.ToString();
        _backcostText.text = abilityCard.Cost.ToString();
        _graphicUI.sprite = abilityCard.Graphic;
        _typeText.text = abilityCard.type.ToString();
        _backypeText.text = abilityCard.type.ToString();
    }
}
