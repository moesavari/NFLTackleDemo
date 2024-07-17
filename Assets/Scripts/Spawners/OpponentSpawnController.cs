///Controller script to assist with controlling all of the opponent spawners

using System.Collections.Generic;
using UnityEngine;

public class OpponentSpawnController : MonoSingleton<OpponentSpawnController>
{
    [SerializeField] private Spawner[] _spawners;

    private List<GameObject> _opponentObjects;

    /// <summary>
    /// Sets up the list to create an object then adds that object to aforementioned list
    /// Also sets the speed of the defender object
    /// </summary>
    public void InstantiateOpponentObjects()
    {
        _opponentObjects = new List<GameObject>();

        foreach(Spawner spawner in _spawners)
        {
            GameObject obj = spawner.InstantiateObject();
            obj.GetComponent<OpponentController>().SetSpeed();
            _opponentObjects.Add(obj);
        }
    }

    /// <summary>
    /// Resets the spawners by deleting all the objects then reinstantiating the list
    /// </summary>
    public void ResetSpwners()
    {
        foreach(GameObject opponent in _opponentObjects)
        {
            Destroy(opponent);
        }

        _opponentObjects.Clear();

        InstantiateOpponentObjects();
    }
}
