using UnityEngine;
using Mirror;

public class SerraturaBehaviour : NetworkBehaviour
{
    public GameObject Topini;
    private Animator anim;
    private int sol = 0;

    [SyncVar(hook = nameof(OnApertaChanged))]
    private bool aperta = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Topini.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnApertaChanged(bool oldValue, bool newValue)
    {
        if(newValue)
        {
            anim.Play("Apertura");
            Topini.SetActive(true);
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdSetAperta(bool newValue)
    {
        aperta = newValue;
    }

    public void Click(int t)
    {
        if(!aperta)
        {
            if(t == 0)
            {
                anim.Play("SX");
            }else{
                anim.Play("DX");
            }
            if(sol == 0 && t == 0)
            {
                sol += 1;
                return;
            }
            if(sol == 0 && t == 1)
            {
                sol = 0;
                return;
            }

            if(sol == 1 && t == 0)
            {
                sol += 1;
                return;
            }
            if(sol == 1 && t == 1)
            {
                sol = 0;
                return;
            }

            if(sol == 2 && t == 0)
            {
                sol += 1;
                return;
            }
            if(sol == 2 && t == 1)
            {
                sol = 0;
                return;
            }

            if(sol == 3 && t == 1)
            {
                sol += 1;
                return;
            }
            if(sol == 3 && t == 0)
            {
                sol = 0;
                return;
            }

            if(sol == 4 && t == 1)
            {
                sol += 1;
                CmdSetAperta(true);
                return;
            }
            if(sol == 4 && t == 0)
            {
                sol = 0;
                return;
            }
        }
    }
}
