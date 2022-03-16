using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cell : MonoBehaviour
{
    private Button _button;
    private Image _image;
    private TextMeshProUGUI _text;
    private int _value;
    private int _x;
    private int _y;

    public event System.Action<int, int> OnClickEvent;

    private void Awake()
    {
        _image = GetComponentInChildren<Image>();
        _button = GetComponentInChildren<Button>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        OnClickEvent?.Invoke(_x, _y);
    }

    public void Set(int x, int y, int value)
    {
        _x = x;
        _y = y;
        _value = value;
        if (value == 0)
        {
            _image.gameObject.SetActive(false);
        }
        else
        {
            if (!_image.gameObject.activeInHierarchy)
            {
                _image.gameObject.SetActive(true);
            }

            _text.text = value.ToString();
        }
    }
}