using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour, IBuffable
{
    [SerializeField] MeshRenderer _renderer = null;
    [SerializeField] Color _initalColor = Color.green;
    [SerializeField] Color _buffColor = Color.red;

    private void Awake()
    {
        _renderer.material.color = _initalColor;
    }

    public void Buff()
    {
        Debug.Log("!Buff Feedback!");
            _renderer.material.color = _buffColor;
    }

    public void Unbuff()
    {
        Debug.Log("...Unbuff Feedback...");
        _renderer.material.color = _initalColor;
    }
}
