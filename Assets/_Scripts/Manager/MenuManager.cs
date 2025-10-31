using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject _selectHeroObject, _tileInfoObject, _tileUnitInfoObject;

    void Awake()
    {
        Instance = this;
    }

    public void ShowSelectedHero(BaseHero hero)
    {
        if (hero == null)
        {
            _selectHeroObject.SetActive(false);
            return;
        }

        _selectHeroObject.GetComponentInChildren<Text>().text = hero.UnitName;
        _selectHeroObject.SetActive(true);
    }

    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            _selectHeroObject.SetActive(false);
            _tileUnitInfoObject.SetActive(false);
            return;
        }

        _tileInfoObject.GetComponentInChildren<Text>().text = tile.TileName;
        _tileInfoObject.SetActive(true);

        if (tile.OccupiedUnit)
        {
            _tileUnitInfoObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.UnitName;
            _tileUnitInfoObject.SetActive(true);
        }
    }

}
