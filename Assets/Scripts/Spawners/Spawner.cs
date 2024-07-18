///General spawner script to assist with spawning either player or opponent objects

using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum SpawnTypes
    {
        PLAYER,
        OPPONENT,
    }

    public SpawnTypes SpawnType;

    public enum PositionTypes
    {
        END,
        TACKLE,
        LINEBACKER,
        CORNERBACK,
        SAFETY,
    }

    /// <summary>
    /// HideIf functions are from Stulk3's HideIf package. 
    /// </summary>
    [SerializeField, HideIfEnumValue("SpawnType", HideIf.NotEqual, (int)SpawnTypes.PLAYER)]
    private GameObject _playerObject;

    [SerializeField, HideIfEnumValue("SpawnType", HideIf.NotEqual, (int)SpawnTypes.OPPONENT)]
    private GameObject _opponentObject;

    [SerializeField, HideIfEnumValue("SpawnType", HideIf.NotEqual, (int)SpawnTypes.OPPONENT)]
    public PositionTypes PositionType;

    private GameObject _spawnObject;

    private void Awake()
    {
        _spawnObject = SpawnType == SpawnTypes.PLAYER ? _playerObject : _opponentObject;
    }

    /// <summary>
    /// A way to denote whether an object is of type Player or Opponent
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = SpawnType == SpawnTypes.PLAYER ? Color.green : Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));
    }

    public GameObject InstantiateObject()
    {
        return Instantiate(_spawnObject, transform.position, Quaternion.identity, transform);
    }
}
