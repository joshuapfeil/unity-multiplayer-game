using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
public class Managers : MonoBehaviour
{
    public static PlayerManager WhitePlayer { get; private set; }
    public static InventoryManager WhiteInventory { get; private set; }
    public static PlayerManager BluePlayer { get; private set; }
    public static InventoryManager BlueInventory { get; private set; }

    private List<IGameManager> StartSequence;

    private void Awake()
    {
        WhitePlayer = GetComponents<PlayerManager>()[0].playerName == "White" ? GetComponents<PlayerManager>()[0] : GetComponents<PlayerManager>()[1];
        WhiteInventory = GetComponents<InventoryManager>()[0];
        BluePlayer = GetComponents<PlayerManager>()[1].playerName == "Blue" ? GetComponents<PlayerManager>()[1] : GetComponents<PlayerManager>()[0];
        BlueInventory = GetComponents<InventoryManager>()[1];

        StartSequence = new List<IGameManager>();
        StartSequence.Add(WhitePlayer);
        StartSequence.Add(WhiteInventory);
        StartSequence.Add(BluePlayer);
        StartSequence.Add(BlueInventory);

        StartCoroutine(StartUpManagers());
    }

    private IEnumerator StartUpManagers()
    {
        foreach (IGameManager manager in StartSequence)
        {
            manager.Startup();
        }
        yield return null;

        int numModules = StartSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach (IGameManager manager in StartSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }

            if (numReady > lastReady)
            {
                Debug.Log("Progress: " + numReady + "/" + numModules);
                
            }
            yield return null;
        }
        Debug.Log("All "+ gameObject.name +" started up");
    }
}
