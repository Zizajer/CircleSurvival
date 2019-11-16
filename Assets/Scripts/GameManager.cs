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
    public int BombDestroyedDifficultyChangeValue;
    public float MinimumTimeToSpawnBombStepDecrementationValue;
    public float MaximumTimeToSpawnBombStepDecrementationValue;
    private int BombsDifficultyChangeValue;

    private void Start()
    {
        isGameEnded = false;
        BombsDifficultyChangeValue = BombDestroyedDifficultyChangeValue;
        Invoke("SpawnABombOnFreeTile",
            Random.Range(MinimumTimeToSpawnABomb, MaximumTimeToSpawnABomb));
    }

    private void Update()
    {
        if (BombManager.BombsDestroyed > BombsDifficultyChangeValue)
        {
            BombsDifficultyChangeValue += BombDestroyedDifficultyChangeValue;

            if(MinimumTimeToSpawnABomb > 0.15f)
                MinimumTimeToSpawnABomb -= MinimumTimeToSpawnBombStepDecrementationValue;

            if (MaximumTimeToSpawnABomb > 0.15f)
                MaximumTimeToSpawnABomb -= MaximumTimeToSpawnBombStepDecrementationValue;
        }
    }

    public void SpawnABombOnFreeTile()
    {
        if (!isGameEnded)
        {
            Tile freeTile = Grid.GetFreeTile();
            BombManager.SpawnBomb(freeTile);
            freeTile.IsBombSetted = true;

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
