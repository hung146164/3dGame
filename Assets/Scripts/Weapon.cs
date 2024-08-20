using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public PhotonView photonView;
    public Camera camera;

    public string nameWeapon;

    public int bullets = 100;
    public int bulletsInTape = 20;

    public float fireRate = 1f;

    public float nextFire = 0f;

    public GameObject hitVFX;
    private void Start()
    {

    }
    private void Update()
    {
        if(photonView.IsMine)
        {
            nextFire -= Time.deltaTime;
            if (Input.GetMouseButton(0) && nextFire <= 0)
            {
                nextFire = 1 / fireRate;
                Fire();
            }
        }
       
    }
    public void Fire()
    {
        Ray ray=new Ray(camera.transform.position,camera.transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray.origin,ray.direction, out hit,100f)) { 
            Instantiate(hitVFX,hit.point,Quaternion.identity);    
        }
    }
    public void Active()
    {
        gameObject.SetActive(true);
    }
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
