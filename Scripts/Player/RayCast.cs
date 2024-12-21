using UnityEngine;
using Mirror;

public class RayCast : NetworkBehaviour
{
    public TetrisManager tm;

    public GameObject sangueLocal;
    public GameObject torciaLocal;
    public GameObject tamponeLocal;

    public Transform origin;

    private int maxDistance = 1;

    void Start()
    {
        tm = GameObject.Find("Tetris Manager").GetComponent<TetrisManager>();

        sangueLocal.SetActive(false);
        torciaLocal.SetActive(true);
        tamponeLocal.SetActive(false);
    }

    void Update()
    {
        if(!isLocalPlayer) return;

        if (Physics.Raycast(origin.position, origin.forward, out RaycastHit hitInfo1, maxDistance*2, LayerMask.GetMask("Pickable")))
        {
            if(hitInfo1.collider.CompareTag("Topino")) //Topino
            {
                if(Input.GetKeyDown(KeyCode.E) && !sangueLocal.activeSelf)
                {
                    sangueLocal.SetActive(true);
                    CmdTopinoSlayer(hitInfo1.collider.gameObject);
                }
            }
            if(hitInfo1.collider.CompareTag("Tampone")) //Tampone
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    torciaLocal.SetActive(false);
                    tamponeLocal.SetActive(true);
                }
            }
            if(hitInfo1.collider.CompareTag("Tetris")) //Tetris
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    InteractionTetris click = hitInfo1.collider.GetComponent<InteractionTetris>();
                    tm.CmdIncrementTcounter();
                    click.Click();
                }
            }
            if(hitInfo1.collider.CompareTag("RedButton")) //RedButton
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    InteractionRedButton click = hitInfo1.collider.GetComponent<InteractionRedButton>();
                    click.Click();
                }
            }
        }
        if (Physics.Raycast(origin.position, origin.forward, out RaycastHit hitInfo, maxDistance))
        {
            if(hitInfo.collider.CompareTag("GiraProvette")) //GiraProvette
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    InteractionGiraProvette click = hitInfo.collider.GetComponent<InteractionGiraProvette>();
                    click.Click(torciaLocal, tamponeLocal, sangueLocal);
                }
            }
            if(hitInfo.collider.CompareTag("BlackSX")) //BlackSX
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    InteractionTasto click = hitInfo.collider.GetComponent<InteractionTasto>();
                    click.Click(0);
                }
            }
            if(hitInfo.collider.CompareTag("BlackDX")) //BlackDX
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    InteractionTasto click = hitInfo.collider.GetComponent<InteractionTasto>();
                    click.Click(1);
                }
            }
            if(hitInfo.collider.CompareTag("Porta")) //Porta
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    InteractionPorta click = hitInfo.collider.GetComponent<InteractionPorta>();
                    click.Click();
                }
            }
            if(hitInfo.collider.CompareTag("Tubo")) //Tubo
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    InteractionTube click = hitInfo.collider.GetComponent<InteractionTube>();
                    click.Click();
                }
            }
            if(hitInfo.collider.CompareTag("Tastierino")) //Tastierino
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    InteractionTast click = hitInfo.collider.GetComponent<InteractionTast>();
                    click.Click();
                }
            }
        }

        Debug.DrawRay(origin.position, origin.forward * (maxDistance*2), Color.green);
        Debug.DrawRay(origin.position, origin.forward * maxDistance, Color.red);
    }

    [ClientRpc]
    public void RpcTopinoSlayer(GameObject topino)
    {
        Destroy(topino);
    }

    [Command(requiresAuthority = false)]
    public void CmdTopinoSlayer(GameObject topino)
    {
        Destroy(topino);
        RpcTopinoSlayer(topino);
    }
}
