using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(GridData), menuName = "Scriptables/GridData")]
public class GridData : ScriptableObject
{
    [Range(1, 50)] public int Width;
    [Range(1, 50)] public int Height;
    public GameObject GridWallPrefab;

    public Action<GridData> OnGridDataChanged;

    public float WallSize => GridWallPrefab.transform.localScale.z;
    public float HalfWallSize => WallSize * 0.5f;

    private void OnValidate()
        => OnGridDataChanged?.Invoke(this);
}

[System.Flags]
public enum WallState
{
    TOP = 1, // 0000 0001
    RIGHT = 2, // 0000 0010
    BOTTOM = 4, // 0000 0100
    LEFT = 8 // 0000 1000
}