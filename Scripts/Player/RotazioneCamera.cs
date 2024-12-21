using UnityEngine;
using Mirror;

public class RotazioneCamera : NetworkBehaviour
{
    //Telecamera
    private bool attivo = true;

    private float vRotazioneX;
    private float vRotazioneY;

    private float rotazioneX;
    private float rotazioneY;

    public Transform cameraPos;
    public Transform tPlayer;

    //Mouse
    private float mouseX;
    private float mouseY;

    private void CameraUpdate()
    {
        transform.position = cameraPos.position;

        rotazioneX += vRotazioneX * mouseX * Time.deltaTime;
        rotazioneY += vRotazioneY * -mouseY * Time.deltaTime;
        rotazioneY = Mathf.Clamp(rotazioneY, -70f, 60f);

        Quaternion deltaRotazioneY = Quaternion.Euler(new Vector3(rotazioneY, 180f, 0));
        Quaternion deltaRotazioneX = Quaternion.Euler(new Vector3(0, rotazioneX, 0));

        transform.localRotation = deltaRotazioneY;

        tPlayer.localRotation = deltaRotazioneX;
    }

    private void CheckInput()
    {
        //Mouse Input
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    void Start()
    {
        if(!isLocalPlayer)
            gameObject.SetActive(false);
        //Mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Telecamera
        vRotazioneX = 300.0f;
        vRotazioneY = 150.0f;
    }

    void Update()
    {
        if(!isLocalPlayer) return;

        if(attivo)
        {
             //Input
            CheckInput();

            //Camera
            CameraUpdate();
        }
    }

    public void setAttivo(bool att)
    {
        attivo = att;
    }
}