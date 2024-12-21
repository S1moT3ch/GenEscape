using UnityEngine;
using Mirror;

public class InteractionPorta : NetworkBehaviour
{
    private bool apribile = false;
    [SyncVar(hook = nameof(OnApertaChanged))]
    private bool aperta = false;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApertaChanged(bool oldValue, bool newValue)
    {
        if(newValue && !oldValue)
        {
            anim.Play("Apertura");
            aperta = true;
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdSetAperta(bool newValue)
    {
        aperta = newValue;
    }

    public void Set()
    {
        apribile = true;
    }

    public void Click()
    {
        if(!aperta)
        {
            if(apribile)
            {
                CmdSetAperta(true);
            }
            else
            {
                anim.Play("Maniglia");
            }
        }
    }
}
