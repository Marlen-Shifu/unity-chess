using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : BasePiece
{
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        //place for movment
        //place for loading piece sprite
    }

    private void CreateCellPath(int flapper)
    {
        int currentX = mCurrentCell.mBoardPosition.x;
        int currentY = mCurrentCell.mBoardPosition.y;

        MatchesState(currentX - 2, currentY + (1 * flapper));
        MatchesState(currentX - 1, currentY + (2 * flapper));
        MatchesState(currentX + 1, currentY + (2 * flapper));
        MatchesState(currentX + 2, currentY + (1 * flapper));

    }

    protected override void CheckPathing()
    {
        CreateCellPath(1);
        CreateCellPath(-1);
    }

    private void MatchesState(int targetX, int targetY)
    {
        CellState cellState = CellState.None;
        cellState = mCurrentCell.mBoard.ValidateCell(targetX, targetY, this);

        try
        {
            if (cellState != CellState.Friendly && cellState != CellState.OutOfBounds)
            mHighlightedCells.Add(mCurrentCell.mBoard.mAllCells[targetX, targetY]);
        }
        catch
        {}
    }
}
