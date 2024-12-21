using UnityEngine;

public class InteractionTasto : MonoBehaviour
{
    public SerraturaBehaviour sb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(int t)
    {
        sb.Click(t);
    }
}
