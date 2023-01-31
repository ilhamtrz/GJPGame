using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public float speed;
    public bool isP1;
    public int totalPoint;

    public int maxAmmo;
    public int currentAmmo;

    public float reloadTime;
    private float reloadTimer;

    public float reloadPerAmmoTime;
    private float reloadPerAmmoTimer;

    public bool isReloading;
    private void Start()
    {
        reloadTimer = reloadTime;
        reloadPerAmmoTimer = reloadPerAmmoTime;
        currentAmmo = maxAmmo;
        isReloading = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isP1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.position -= new Vector3(speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.position += new Vector3(speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.position += new Vector3(0f, speed, 0f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position -= new Vector3(0f, speed, 0f);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.position -= new Vector3(speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3(speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.transform.position += new Vector3(0f, speed, 0f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.position -= new Vector3(0f, speed, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentAmmo > 0 && !isReloading)
            {
                Shoot();
            }
        }
        if(currentAmmo <= 0)
        {
            reloadTimer -= 1 * Time.deltaTime;
            if (reloadTimer <= 0)
            {
                Reload();
                reloadTimer = reloadTime;
                isReloading = false;
            }

        }
    }

    void Shoot()
    {
        RaycastHit hit;
        
        if(Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
        {
            Debug.Log(hit.transform.tag);

            TargetMover target = hit.transform.GetComponent<TargetMover>();
            Crow crow = hit.transform.GetComponent<Crow>();
            if(target != null)
            {
                target.Die();
                totalPoint += target.point;
            }
            if(crow != null)
            {
                crow.Die();
                totalPoint -= crow.point;
            }
        }
        currentAmmo -= 1;
    }

    void Reload()
    {
        isReloading = true;
        currentAmmo = maxAmmo;
    }

    void ReloadPerAmmo()
    {
        isReloading = true;

        for (int i = currentAmmo; i < maxAmmo; i++)
        {
            reloadPerAmmoTimer -= 1 * Time.deltaTime;
            if (reloadPerAmmoTimer <= 0)
            {
                Debug.Log("isi ammo 1");
                currentAmmo = currentAmmo + 1;
                reloadPerAmmoTimer = reloadPerAmmoTime;
            }
            Debug.Log(i);
        }
        isReloading = false;
    }
}
