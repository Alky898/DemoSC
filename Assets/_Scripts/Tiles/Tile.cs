using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;

    public BaseUnit OccupiedUnit;
    public bool Walkable => _isWalkable && OccupiedUnit == null;

    public string TileName;

    public virtual void Init(int x, int y)
    {

    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
        MenuManager.Instance.ShowTileInfo(this);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);
    }

    void OnMouseDown()
    {
        //checking if it is the heroes turn
        if (GameManager.Instance.GameState != GameState.HeroesTurn) return;

        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.faction == Faction.Hero)
            {
                UnitManager.Instance.SetSelectedHero((BaseHero)OccupiedUnit);
            }
            else
            {
                if (UnitManager.Instance.SelectedHero != null)
                {
                    var enemy = (BaseEnemy)OccupiedUnit;
                    // Destorying the enemy after selecting the heroes
                    Destroy(enemy.gameObject);

                    //Deselecting the unit after the action
                    UnitManager.Instance.SetSelectedHero(null);
                }
            }
        }
        else
        {
            if (UnitManager.Instance.SelectedHero != null)
            {
                setUnit(UnitManager.Instance.SelectedHero);
                UnitManager.Instance.SetSelectedHero(null);

            }
        }
    }

    public void setUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
}

