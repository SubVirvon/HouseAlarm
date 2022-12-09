using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction<bool> Clicked
    {
        add => _clicked.AddListener(value);
        remove => _clicked.RemoveListener(value);
    }

    [SerializeField] private UnityEvent<bool> _clicked;

    private bool _isCharacterInside = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isCharacterInside)
            _isCharacterInside = false;
        else
            _isCharacterInside = true;

        _clicked?.Invoke(_isCharacterInside);
    }
}
