﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CellState
{
    None,
    Friendly,
    Enemy,
    Free,
    OutOfBounds
}

public class Board : MonoBehaviour
{

    public GameObject mCellPrefab;

    [HideInInspector]
    public Cell[,] mAllCells = new Cell[8, 8];
    // Start is called before the first frame update

    public void Create()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                GameObject newCell = Instantiate(mCellPrefab, transform);

                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 90), (y * 90));

                mAllCells[x, y] = newCell.GetComponent<Cell>();
                mAllCells[x, y].Setup(new Vector2Int(x, y), this);
            }
        }

        for (int x = 0; x < 8; x += 2)
        {
            for (int y = 0; y < 8; y++)
            {
                int offset = (y % 2 != 0) ? 0 : 1;
                int finalX = x + offset;

                mAllCells[finalX, y].GetComponent<Image>().color = new Color32(87, 84, 76, 255);
            }
        }
    }

    public CellState ValidateCell(int targetX, int targetY, BasePiece checkingPiece)
    {
        try
        {
            if (targetX < 0 || targetX > 7)
                return CellState.OutOfBounds;

            if (targetY < 0 || targetX > 7)
                return CellState.OutOfBounds;

            Cell targetCell = mAllCells[targetX, targetY];

            if (targetCell.mCurrentPiece != null)
            {
                if (checkingPiece.mColor == targetCell.mCurrentPiece.mColor)
                    return CellState.Friendly;
                else
                    return CellState.Enemy;

            }

            return CellState.Free;
        }
        catch (System.Exception)
        { return CellState.None; }
    }

}
