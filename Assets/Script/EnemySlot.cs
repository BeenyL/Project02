using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlot : MonoBehaviour
{
    [SerializeField] int slot;
    public int _slot { get => slot; set => slot = value; }
}
