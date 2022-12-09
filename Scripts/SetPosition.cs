using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    [SerializeField] private GameObject _character;

    private Vector2 _position;
    private Renderer _characterRenderer;

    private void Awake()
    {
        _position = new Vector2(transform.position.x, transform.position.y);
        _characterRenderer = _character.GetComponent<Renderer>();
    }

    public void Set(bool isCharacterInside)
    {
        _character.transform.position = _position;

        if (isCharacterInside)
            _characterRenderer.sortingOrder = 1;
        else
            _characterRenderer.sortingOrder = 5;
    }
}
