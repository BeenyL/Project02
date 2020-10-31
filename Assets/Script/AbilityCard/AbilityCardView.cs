using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCardView : MonoBehaviour
{
    [SerializeField] Text _nameTextUI = null;
    [SerializeField] Text _costTextUI = null;
    [SerializeField] Image _graphicUI = null;
    [SerializeField] Text _backcostText = null;
    [SerializeField] Text _backnameText = null;

    public void Display(AbilityCard abilityCard)
    {
        _nameTextUI.text = abilityCard.Name;
        _backnameText.text = abilityCard.Name;
        _costTextUI.text = abilityCard.Cost.ToString();
        _backcostText.text = abilityCard.Cost.ToString();
        _graphicUI.sprite = abilityCard.Graphic;
    }
}
