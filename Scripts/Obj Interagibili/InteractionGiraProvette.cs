using UnityEngine;
using Mirror;

public class InteractionGiraProvette : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnCounterChanged))]
    private int counter = 0;
    private Animator anim;
    [SyncVar(hook = nameof(OnApertoChanged))]
    private bool aperto = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(GameObject torciaLocal, GameObject tamponeLocal, GameObject sangueLocal)
    {
        if(!aperto)
        {
            CmdSetAperto(true);
            return;
        }
        if(aperto && counter != 6 && tamponeLocal.activeSelf && !torciaLocal.activeSelf && sangueLocal.activeSelf)
        {
            CmdSetCounter(counter+1);
            tamponeLocal.SetActive(false);
            sangueLocal.SetActive(false);
        }
    }

    private void OnCounterChanged(int oldValue, int newValue)
    {
        if(newValue == 6)
        {
            anim.Play("Rotazione");
        }
    }

    private void OnApertoChanged(bool oldValue, bool newValue)
    {
        if(newValue)
        {
            anim.Play("Apertura");
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdSetCounter(int newValue)
    {
        counter = newValue;
    }

    [Command(requiresAuthority = false)]
    public void CmdSetAperto(bool newValue)
    {
        aperto = newValue;
    }
}
