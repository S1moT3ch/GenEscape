using UnityEngine;
using Mirror;

public class Tastierino : NetworkBehaviour
{
    public GameObject luci;
    public InteractionPorta port1;
    public InteractionPorta port2;
    public AudioClip clip;
    public AudioSource audioSource;

    [SyncVar(hook = nameof(OnSolvedChanged))]
    private bool solved = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.playOnAwake = false;
        luci.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Puoi aggiungere logica qui se necessiti di qualcosa in ogni frame
    }

    // Questo metodo verrà chiamato ogni volta che la variabile "solved" cambia valore
    private void OnSolvedChanged(bool oldValue, bool newValue)
    {
        // Se "solved" diventa true, esegui le azioni
        if (newValue)
        {
            SetSol();
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdSetSol(bool newSolvedValue)
    {
        solved = newSolvedValue;
    }

    public void SetSolRequest(bool newSolvedValue)
    {
        CmdSetSol(newSolvedValue);
    }

    public void SetSol()
    {
        port1.Set();
        port2.Set();
        luci.SetActive(true);
        audioSource.PlayOneShot(clip);
    }

    public bool GetSol()
    {
        return solved;
    }
}
