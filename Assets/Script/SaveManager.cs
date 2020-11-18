using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] int _currentLevel;
    public int currentLevel { get => _currentLevel; set => _currentLevel = value; }

}
