using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

    [SerializeField] Transform weaponTransform;
    [SerializeField] AudioSource weaponSound;
    [SerializeField] GameObject bullet;

    float delay = 0;
    bool isReloaded;

    void Awake()
    {
        isReloaded = true;
    }

	void Update () 
    {
        if(CheckDelay())
	        SetPosition();
        if(Input.GetMouseButtonDown(0) && isReloaded)
            Shoot();
	}

    bool CheckDelay()
    {
        if (delay > 0.1f) { delay = 0; return true; }
        delay += Time.deltaTime; return false; 
    }

    void SetPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(weaponTransform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angleY = Mathf.Atan2(mousePos.y, -mousePos.x) * Mathf.Rad2Deg + 90;
        weaponTransform.rotation = Quaternion.Euler(new Vector3(0, angleY, 0));
    }

    void Shoot()
    {
        isReloaded = false;
        MoveBullet();
        weaponSound.Play();
        StartReloading();
    }

    void StartReloading()
    {
        float reloadDelay = 0;
        while (reloadDelay < 3.0f)
            reloadDelay += Time.deltaTime;
        isReloaded = true;
    }

    void MoveBullet()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.SetParent(weaponTransform, false);
        newBullet.SetActive(true);
        newBullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 800f;
    }
}
