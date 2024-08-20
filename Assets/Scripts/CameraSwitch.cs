using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CameraManager: MonoBehaviour
{
    public PhotonView photonView;
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    public UIManager uiManager;
    private void Start()
    {
        if (photonView.IsMine)
        {
        SwitchToThirdPerson();

        }
    }

    private void Update()
    {
        if (photonView.IsMine) {
            if (Input.GetMouseButton(1))
            {
                SwitchToFirstPerson();
                return;
            }
            SwitchToThirdPerson();
        }
        


    }

    void SwitchToFirstPerson()
    {
        firstPersonCamera.gameObject.SetActive(true);
        thirdPersonCamera.gameObject.SetActive(false);
        uiManager.aimPoint.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;

    }

    void SwitchToThirdPerson()
    {
        firstPersonCamera.gameObject.SetActive(false);
        thirdPersonCamera.gameObject.SetActive(true);
        uiManager.aimPoint.gameObject.SetActive(false);
    }
}
