using UnityEngine;
using Mirror;

public class InteractionTube : NetworkBehaviour
{
    public Animator animator;
    [SyncVar(hook = nameof(OnApertoChanged))]
    private bool aperto = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnApertoChanged(bool oldValue, bool newValue)
    {
        if(newValue)
        {
            animator.SetBool("aperto", true);
            aperto = true;
        }else{
            animator.SetBool("aperto", false);
            aperto = false;
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdSetAperto(bool newValue)
    {
        aperto = newValue;
    }

    public void Click()
    {
        CmdSetAperto(!aperto);
    }
}
