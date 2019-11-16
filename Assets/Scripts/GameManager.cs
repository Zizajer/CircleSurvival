using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Grid Grid;
    public BombManager BombManager;
    public float MinimumTimeToSpawnABomb;
    public float MaximumTimeToSpawnABomb;
    public UIManager UIManager;
    public ScoreManager ScoreManager;
    private bool isGameEnded;

    private void Start()
    {
        isGameEnded = false;
        Invoke("SpawnABombOnFreeTile",
            Random.Range(MinimumTimeToSpawnABomb, MaximumTimeToSpawnABomb));
    }

    public void SpawnABombOnFreeTile()
    {
        if (!isGameEnded)
        {
            Tile freeTile = Grid.GetFreeTile();
            BombManager.SpawnBomb(freeTile);
            freeTile.isBombSetted = true;

            Invoke("SpawnABombOnFreeTile", 
                Random.Range(MinimumTimeToSpawnABomb, MaximumTimeToSpawnABomb));
        }
    }

    public void EndGame()
    {
        UIManager.ShowEndGameUIAnimations(ScoreManager.CurrentScore);
        BombManager.ExplodeAllActiveBombs();
        isGameEnded = true;
        ScoreManager.enabled = false;
    }
    
}
