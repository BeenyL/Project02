using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCardView : MonoBehaviour
{
    [SerializeField] Text _nameTextUI = null;
    [SerializeField] Text _costTextUI = null;
    [SerializeField] Text _typeText = null;
    [SerializeField] Text _effectText = null;
    [SerializeField] Image _graphicUI = null;
    [SerializeField] Text _backcostText = null;
    [SerializeField] Text _backnameText = null;
    [SerializeField] Text _backypeText = null;
    [SerializeField] Text _backeffectText = null;

    [SerializeField] Color dmgColor;
    [SerializeField] Color mpColor;
    [SerializeField] Color amrColor;

    Color eff_val_color;
    public void Display(AbilityCard abilityCard)
    {
        _nameTextUI.text = abilityCard.Name;
        _backnameText.text = abilityCard.Name;
        _costTextUI.text = abilityCard.Cost.ToString();
        _backcostText.text = abilityCard.Cost.ToString();
        _graphicUI.sprite = abilityCard.Graphic;
        _typeText.text = abilityCard.type.ToString();
        _backypeText.text = abilityCard.type.ToString();
        if(abilityCard.effect.ToString() == "ATT")
        {
            eff_val_color = Color.yellow;
        }
        else if(abilityCard.effect.ToString() == "DMG")
        {
            eff_val_color = dmgColor;
        }
        else if (abilityCard.effect.ToString() == "MP")
        {
            eff_val_color = mpColor;
        }
        else if (abilityCard.effect.ToString() == "HP")
        {
            eff_val_color = Color.green;
        }
        else if (abilityCard.effect.ToString() == "AMR")
        {
            eff_val_color = amrColor;
        }
        _effectText.color = eff_val_color;
        _effectText.text = "+ " + abilityCard.effectValue.ToString() + " " + abilityCard.effect.ToString();
        _backeffectText.text = "+ " + abilityCard.effectValue.ToString() + " " + abilityCard.effect.ToString();
    }
}
