using UnityEngine;
using Mirror;

public class TetrisManager : NetworkBehaviour
{
    public InteractionPorta port1;
    public InteractionPorta port2;
    [SyncVar(hook = nameof(OnTcounterChanged))]
    private int Tcounter;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Command(requiresAuthority = false)]
    public void CmdIncrementTcounter()
    {
        Tcounter++;
    }

    private void OnTcounterChanged(int oldValue, int newValue)
    {
        Debug.Log("Aggiornato");
        Debug.Log(newValue);
        if(newValue == 6)
        {
            port1.Set();
            port2.Set();
        }
    }

    public int Get()
    {
        return Tcounter;
    }
}
