public static class GridGenerator
{
    public static WallState[,] GenerateGrid(GridData gridData)
    {
        WallState[,] grid = new WallState[gridData.Width, gridData.Height];
        WallState initialState = WallState.TOP | WallState.RIGHT | WallState.BOTTOM | WallState.LEFT;

        for (int x = 0; x < gridData.Width; x++)
        {
            for (int z = 0; z < gridData.Height; z++)
            {
                grid[x, z] = initialState;
            }
        }

        return grid;
    }

}
