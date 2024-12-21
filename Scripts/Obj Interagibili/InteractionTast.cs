using UnityEngine;
using TMPro;

public class InteractionTast : MonoBehaviour
{
    public Tastierino tast;
    public TMP_Text uiText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        if(!tast.GetSol())
        {
            uiText.text = uiText.text + gameObject.name;
            if(uiText.text == "96691")
                {
                    tast.SetSolRequest(true);
                }
            if (uiText.text.Length >= 5 && tast.GetSol() == false)
                {
                    uiText.text = "";
                }
        }
    }
}
