using System.Collections.Generic;
using UnityEngine;

public class OpponentSpawnController : MonoSingleton<OpponentSpawnController>
{
    [SerializeField] private Spawner[] _spawners;

    private List<GameObject> _opponentObjects;

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
