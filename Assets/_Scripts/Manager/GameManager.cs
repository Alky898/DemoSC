using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState GameState;

    //Allow me to access GameManager at any state
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //Starting with which states
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnHeroes:
                UnitManager.Instance.SpawnHeroes();
                break;
            case GameState.SpawnEnemy:
                UnitManager.Instance.SpawnEnemy();
                break;
            case GameState.HeroesTurn:
                break;
            case GameState.EnemiesTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(GameState), newState, null);
        }
    }
}

public enum GameState
{
    GenerateGrid = 0,
    SpawnHeroes = 1,
    SpawnEnemy = 2,
    HeroesTurn = 3,
    EnemiesTurn = 4
}