using UnityEngine;
using System.Collections;
using Mirror;

public class Torcia : NetworkBehaviour
{
    public GameObject Luce;
    public GameObject LuceUV;

    public Transform posTorcia;

    //private Animator anim;
    private int stato;

    void Start()
    {
        Luce.SetActive(false);
        LuceUV.SetActive(false);
        stato = 0;
        //anim = gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        if(!isLocalPlayer) return;

        transform.position = posTorcia.position;

        if (Input.GetButtonDown("Fire1"))
        {
            stato += 1;
            //anim.SetTrigger("On");
        }
        if (stato > 2)
            stato = 0;

        switch(stato)
        {
            case 0:
                Luce.SetActive(false);
                LuceUV.SetActive(false);
                break;
            case 1:
                Luce.SetActive(true);
                LuceUV.SetActive(false);
                break;
            case 2:
                Luce.SetActive(false);
                LuceUV.SetActive(true);
                break;
        }
    }
}
