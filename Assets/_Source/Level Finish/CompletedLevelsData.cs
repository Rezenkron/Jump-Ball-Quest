using UnityEngine;
using UnityEngine.SceneManagement;

public static class CompletedLevelsData
{
    private const int LEVELS_AMOUNT = 15;
    public static bool[] isCompleted = new bool[LEVELS_AMOUNT];
}
