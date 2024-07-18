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

            OpponentController opp = obj.GetComponent<OpponentController>();

            opp.SetSpeed();
            opp.SetName(GetNameByPosition(spawner));

            _opponentObjects.Add(obj);
        }
    }

    /// <summary>
    /// This function returns a randomly picked name from the list of player names available
    /// Based on where the spwaner is positioned, it will pick from the appropriate list
    /// </summary>
    /// <param name="spawner"></param>
    /// <returns></returns>
    private string GetNameByPosition(Spawner spawner)
    {
        string name = null;

        switch(spawner.PositionType)
        {
            case Spawner.PositionTypes.CORNERBACK:
                name = PlayerData.CornerbackPlayers[Random.Range(0, PlayerData.CornerbackPlayers.Count)];
                break;
            case Spawner.PositionTypes.END:
                name = PlayerData.EndPlayers[Random.Range(0, PlayerData.EndPlayers.Count)];
                break;
            case Spawner.PositionTypes.LINEBACKER:
                name = PlayerData.LinebackerPlayers[Random.Range(0, PlayerData.LinebackerPlayers.Count)];
                break;
            case Spawner.PositionTypes.SAFETY:
                name = PlayerData.SafetyPlayers[Random.Range(0, PlayerData.SafetyPlayers.Count)];
                break;
            case Spawner.PositionTypes.TACKLE:
                name = PlayerData.TacklePlayers[Random.Range(0, PlayerData.TacklePlayers.Count)];
                break;
        }

        return name;
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
