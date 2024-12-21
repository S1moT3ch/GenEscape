using UnityEngine;
using System.Collections;

public class NeonController : MonoBehaviour
{
    public Material neonMaterial;
    public float delay = 0.5f;
    public float longDelay = 1f;

    private Color red = Color.red;
    private Color blue = Color.blue;
    private int currentStep = 0;

    private void Start()
    {
        StartCoroutine(NeonSequence());
    }

    private IEnumerator NeonSequence()
    {
        while (true) 
        {
            switch (currentStep)
            {
                case 0: // Accendi il neon rosso (sinistra)
                    SetNeonColor(red);
                    yield return new WaitForSeconds(delay);
                    SetNeonColor(Color.black);
                    yield return new WaitForSeconds(delay);
                    break;

                case 1: // Accendi il neon rosso (sinistra)
                    SetNeonColor(red);
                    yield return new WaitForSeconds(delay);
                    SetNeonColor(Color.black);
                    yield return new WaitForSeconds(delay);
                    break;

                case 2: // Accendi il neon rosso (sinistra)
                    SetNeonColor(red);
                    yield return new WaitForSeconds(delay);
                    SetNeonColor(Color.black);
                    yield return new WaitForSeconds(delay);
                    break;

                case 3: // Accendi il neon blu (destra)
                    SetNeonColor(blue);
                    yield return new WaitForSeconds(delay);
                    SetNeonColor(Color.black);
                    yield return new WaitForSeconds(delay);
                    break;

                case 4: // Accendi il neon blu (destra)
                    SetNeonColor(blue);
                    yield return new WaitForSeconds(delay);
                    SetNeonColor(Color.black);
                    yield return new WaitForSeconds(delay);
                    break;
            }

            currentStep = (currentStep + 1) % 5;
        }
    }

    private void SetNeonColor(Color color)
    {
        if (neonMaterial != null)
        {
            neonMaterial.SetColor("_EmissionColor", color);
            if (color != Color.black)
            {
                neonMaterial.EnableKeyword("_EMISSION");
            }
            else
            {
                neonMaterial.DisableKeyword("_EMISSION");
            }
        }
    }
}
