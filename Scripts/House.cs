using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private Renderer _houseFrontRenderer;
    [SerializeField] private GameObject _houseBack;
    [SerializeField] private float _transparency;

    private Color _houseFrontColor;

    public void OnEnable()
    {
        _houseFrontColor = _houseFrontRenderer.material.color;
        _houseBack.SetActive(false);
        _door.Clicked += OnDoorClicked;
    }

    private void OnDisable()
    {
        _door.Clicked -= OnDoorClicked;
    }

    private void OnDoorClicked(bool isCharacterInside)
    {
        

        if (isCharacterInside)
        {
            _houseBack.SetActive(true);
            _houseFrontRenderer.material.color = new Color(_houseFrontColor.r, _houseFrontColor.g, _houseFrontColor.b, _transparency);
        }
        else
        {
            _houseBack.SetActive(false);
            _houseFrontRenderer.material.color = _houseFrontColor;
        }
    }
}
