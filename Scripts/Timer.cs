using TMPro;
using UnityEngine;
using Mirror;

public class Countdown : NetworkBehaviour
{
    public TextMeshPro countdownText1;
    public TextMeshPro countdownText2;
    public TextMeshPro countdownText3;

    [SyncVar(hook = nameof(OnTimeRemainingChanged))]
    private float timeRemaining = 3600f;

    private void Start()
    {
        // Solo il server inizializza e aggiorna il countdown
        if (isServer)
        {
            InvokeRepeating(nameof(UpdateCountdown), 1f, 1f); // Aggiorna il countdown ogni secondo
        }
    }

    void Update()
    {
        // Solo i client devono aggiornare il testo quando cambia timeRemaining
    }

    void UpdateCountdown()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= 1f;
        }

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            CancelInvoke(nameof(UpdateCountdown)); // Stoppa il countdown
        }
    }

    // Questo metodo viene chiamato ogni volta che il SyncVar cambia
    void OnTimeRemainingChanged(float oldTime, float newTime)
    {
        // Qui aggiorniamo i testi del countdown sui client
        UpdateCountdownText();
    }

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        string timeFormatted = string.Format("{0:D2}:{1:D2}", minutes, seconds);

        countdownText1.text = timeFormatted;
        countdownText2.text = timeFormatted;
        countdownText3.text = timeFormatted;
    }
}
