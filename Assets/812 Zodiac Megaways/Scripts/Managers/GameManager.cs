using UnityEngine;
using System;
using Unity.Profiling;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(!instance)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }

    private string[] levels;

    public static Action OnGameStarted { get; set; } = delegate { };
    public static Action<bool> OnGameFinished { get; set; } = delegate { };

    private void Awake()
    {
        TextAsset levelsAssets = Resources.Load("Levels/0", typeof(TextAsset)) as TextAsset;
        levels = levelsAssets.text.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
    }

    public void StartGame()
    {
        OnGameStarted?.Invoke();
        WordEntity.SetWord(levels[UnityEngine.Random.Range(0, levels.Length)]);
    }
}