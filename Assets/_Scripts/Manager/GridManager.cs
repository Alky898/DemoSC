using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public static GridManager Instance;
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _grassTile, _mountainTile, _forestTile;

    [SerializeField] private Transform _cam;
    private Dictionary<Vector2, Tile> _tiles;

    void Awake()
    {
        Instance = this;
    }

    //Creating tiles on the map
    public void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                //var randomTile = Random.Range(0, 6) == 3 ? _mountainTile : _grassTile;

                // SilenceChess
                var randomTile = Random.Range(0, 6) == 3 ? _mountainTile : Random.Range(0, 6) == 2 ? _forestTile : _grassTile;
                Debug.Log(randomTile);
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                //setting whether the tiles are even or not
                spawnedTile.Init(x, y);

                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        //changing the camera into the middle
        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);

        GameManager.Instance.ChangeState(GameState.SpawnHeroes);
    }
    //Spawnning the units
    public Tile GetHeroSpawnTile()
    {
        return _tiles.Where(t => t.Key.x < _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetEnemySpawnTile()
    {
        return _tiles.Where(t => t.Key.x > _width / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }


}
