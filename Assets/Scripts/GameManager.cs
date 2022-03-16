using System;
using System.Collections;
using System.Collections.Generic;
using FLibrary;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private const int SIZE = 4;
    private Board _board;
    private Game _game;

    private void Awake()
    {
        _board = GetComponentInChildren<Board>();
        _game = new Game(SIZE);
    }

    private void Start()
    {
        var elementsCount = SIZE * SIZE;
        var counter = 0;
        for (int y = 0; y < SIZE; y++)
        {
            for (int x = 0; x < SIZE; x++)
            {
                _board.Set(counter++, 0, y, x);
            }
        }

        _board.OnClickEvent += OnClick;
    }

    private void OnDestroy()
    {
        _board.OnClickEvent -= OnClick;
    }

    private void OnClick(int x, int y)
    {
        _game.PressAt(x, y);
        UpdateBoard();
    }

    private void UpdateBoard()
    {
        var counter = 0;
        for (int y = 0; y < SIZE; y++)
        {
            for (int x = 0; x < SIZE; x++)
            {
                _board.Set(counter++, _game.GetDigitAt(x, y), x, y);
            }
        }
    }

    public void StartPlay()
    {
        _game.Start(Random.Range(0, 1000));
        var counter = 0;
        for (int y = 0; y < SIZE; y++)
        {
            for (int x = 0; x < SIZE; x++)
            {
                _board.Set(counter++, _game.GetDigitAt(x, y), x, y);
            }
        }
    }
}