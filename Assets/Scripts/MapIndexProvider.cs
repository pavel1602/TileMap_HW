using UnityEngine;

public class MapIndexProvider : MonoBehaviour
{
    [SerializeField] private Map _map;

    public Vector2Int GetIndex(Vector3 worldPosition)
    {
        var halfMapSize = _map.Size / 2;
        var titlePositionInMap = _map.transform.InverseTransformPoint(worldPosition);
        var x = Mathf.FloorToInt(titlePositionInMap.x);
        var y = Mathf.FloorToInt(titlePositionInMap.z);

        var mapIndex = new Vector2Int(x, y) + halfMapSize;
        return ClampMapIndex(mapIndex);
    }

    public Vector3 GetTilePosition(Vector2Int index)
    {
        var halfMapSize = _map.Size / 2;
        var halfTileSize = Vector2.one / 2;
        var tilePositioXY = (index - halfMapSize) + halfTileSize;
        return new Vector3(tilePositioXY.x, 0, tilePositioXY.y);
    }

    private Vector2Int ClampMapIndex(Vector2Int mapIndex)
    {
        var clampedX = Mathf.Clamp(mapIndex.x, 0, _map.Size.x - 1);
        var clampedY = Mathf.Clamp(mapIndex.y, 0, _map.Size.y - 1);

        var mapIndexClamped = new Vector2Int(clampedX, clampedY);
        return mapIndexClamped;
    }
}