using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent<bool> _clicked;

    private bool _isCharacterInside = false;

    public event UnityAction<bool> Clicked
    {
        add => _clicked.AddListener(value);
        remove => _clicked.RemoveListener(value);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _isCharacterInside = !_isCharacterInside;

        _clicked?.Invoke(_isCharacterInside);
    }
}
