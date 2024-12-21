using UnityEngine;
using Mirror;

public class InteractionRedButton : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnAttivoChanged))]
    private bool attivo = true;

    public GameObject Lasers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnAttivoChanged(bool oldValue, bool newValue)
    {
        if(!newValue)
        {
            Lasers.SetActive(false);
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdSetAttivo(bool newValue)
    {
        attivo = newValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        CmdSetAttivo(false);
    }
}
