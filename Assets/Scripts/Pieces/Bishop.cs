using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : BasePiece
{
    public override void Setup(Color newTeamColor, Color32 newSpriteColor, PieceManager newPieceManager)
    {
        base.Setup(newTeamColor, newSpriteColor, newPieceManager);

        mMovement = new Vector3Int(0, 0, 7);
        //place for loading piece sprite
    }
}
