using UnityEngine;
using Mirror;

public class InteractionTetris : NetworkBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ClientRpc]
    public void RpcUpdatePosition(Transform t, Vector3 new1, Vector3 new2)
    {
        t.parent.localPosition = new1;
        t.localPosition = new2;
    }

    [Command(requiresAuthority = false)]
    void CmdMoveObject(Transform t, Vector3 new1, Vector3 new2)
    {
        t.parent.localPosition = new1;
        t.localPosition = new2;
        RpcUpdatePosition(t, new1, new2);
    }

    public void Click()
    {
        if(gameObject.name == "11")
        {
            CmdMoveObject(gameObject.GetComponent<Transform>(), new Vector3(-4.525f, -0.0407f, -4.4531f), new Vector3(0.0169f, 0f, 0.0027f));
        }
        if(gameObject.name == "12")
        {
            CmdMoveObject(gameObject.GetComponent<Transform>(), new Vector3(-4.52559996f,-0.0430000015f,-4.44939995f), new Vector3(0.0489999987f,-0.0115f,0f));
        }
        if(gameObject.name == "6")
        {
            CmdMoveObject(gameObject.GetComponent<Transform>(), new Vector3(-4.83109999f,-0.0109999999f,-4.43520021f), new Vector3(-0.0104f,-0.307999998f,-0.0131999999f));
        }
        if(gameObject.name == "4")
        {
            CmdMoveObject(gameObject.GetComponent<Transform>(), new Vector3(-4.04400015f,-0.393000007f,-3.51200008f), new Vector3(-0.301999986f,0.347000003f,-0.938000023f));
        }
        if(gameObject.name == "7")
        {
            CmdMoveObject(gameObject.GetComponent<Transform>(), new Vector3(-4.43200016f,0.0680000037f,-4.36399984f), new Vector3(-0.0896999985f,0.0904000029f,-0.0859000012f));
        }
        if(gameObject.name == "1")
        {
            CmdMoveObject(gameObject.GetComponent<Transform>(), new Vector3(-3.61085486f,-0.56400001f,-1.68340683f), new Vector3(-0.917999983f,0.539300025f,-2.7650001f));

        }
    }
}
