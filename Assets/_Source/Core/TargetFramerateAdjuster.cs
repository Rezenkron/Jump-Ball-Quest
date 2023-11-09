using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFramerateAdjuster : MonoBehaviour
{
    [SerializeField, Tooltip("Default = 30\nNo limit = -1 \nRecommended = 60")] private int targetFrameRate;
    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
    }
}
