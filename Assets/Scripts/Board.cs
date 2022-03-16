using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Cell[] _cells;
    public event System.Action<int, int> OnClickEvent; 

    private void Awake()
    {
        _cells = GetComponentsInChildren<Cell>();
    }

    private void Start()
    {
        foreach (Cell cell in _cells)
        {
            cell.OnClickEvent += OnClick;
        }
    }

    private void OnDestroy()
    {
        foreach (Cell cell in _cells)
        {
            cell.OnClickEvent -= OnClick;
        }
    }

    private void OnClick(int x, int y)
    {
        OnClickEvent?.Invoke(x, y);
    }

    public void Set(int index, int value, int x, int y)
    {
        _cells[index].Set(x, y, value);
    }
}