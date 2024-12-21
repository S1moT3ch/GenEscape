using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public Transform spawnPoint1; // Primo punto di spawn
    public Transform spawnPoint2; // Secondo punto di spawn

    private int playerCount = 0;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Transform spawnPoint = null;

        // Decidi il punto di spawn in base al numero di giocatori
        if (playerCount == 0)
        {
            spawnPoint = spawnPoint1;
        }
        else if (playerCount == 1)
        {
            spawnPoint = spawnPoint2;
        }
        else
        {
            Debug.LogWarning("Limite di giocatori raggiunto.");
            return;
        }

        // Aumenta il conteggio dei giocatori
        playerCount++;

        // Instanzia il giocatore nel punto di spawn designato
        GameObject player = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

        // Aggiungi il giocatore al server
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
