using UnityEngine;

public class GridRenderer : MonoBehaviour
{
    public GridData CurrentData;


    private void Awake()
    {
        WallState[,] grid = GridGenerator.GenerateGrid(CurrentData);
        RenderGrid(grid);
    }

    private void RenderGrid(WallState[,] grid)
    {
        for (int x = 0; x < CurrentData.Width; x++)
        {
            for (int z = 0; z < CurrentData.Height; z++)
            {
                CreateCell(grid, x, z);
            }
        }
    }

    private void CreateCell(WallState[,] grid, int x, int z)
    {
        WallState gridCellState = grid[x, z];
        Vector3 gridCellCenterPos = new Vector3(x * CurrentData.WallSize, 0, z * CurrentData.WallSize);

        if (gridCellState.HasFlag(WallState.LEFT))
        {
            GameObject gridWallInstance = Instantiate(CurrentData.GridWallPrefab, this.transform);
            gridWallInstance.transform.position = gridCellCenterPos + new Vector3(-CurrentData.HalfWallSize, 0, 0);
        }
        
        if (gridCellState.HasFlag(WallState.TOP))
        {
            GameObject gridWallInstance = Instantiate(CurrentData.GridWallPrefab, this.transform);
            gridWallInstance.transform.eulerAngles = new Vector3(0, 90, 0);
            gridWallInstance.transform.position = gridCellCenterPos + new Vector3(0, 0, CurrentData.HalfWallSize);
        }
        
        if (gridCellState.HasFlag(WallState.RIGHT))
        {
            GameObject gridWallInstance = Instantiate(CurrentData.GridWallPrefab, this.transform);
            gridWallInstance.transform.eulerAngles = new Vector3(0, 180, 0);
            gridWallInstance.transform.position = gridCellCenterPos + new Vector3(CurrentData.HalfWallSize, 0, 0);
        }
        
        if (gridCellState.HasFlag(WallState.BOTTOM))
        {
            GameObject gridWallInstance = Instantiate(CurrentData.GridWallPrefab, this.transform);
            gridWallInstance.transform.eulerAngles = new Vector3(0, -90, 0);
            gridWallInstance.transform.position = gridCellCenterPos + new Vector3(0, 0, -CurrentData.HalfWallSize);
        }
    }
}