using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] private Color _offsetColor, _baseColor;

    public override void Init(int x, int y)
    {
        // ..Grid Example
        //checker-board pattern
        //var isOffset = (x + y) % 2 == 1;
        //_renderer.color = isOffset ? _offsetColor : _baseColor;
        _renderer.color = _baseColor;
    }

}
