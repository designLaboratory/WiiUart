using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class WeaponController : MonoBehaviour
{

    [SerializeField] Transform weaponTransform;
    [SerializeField] AudioSource weaponSound;
    [SerializeField] GameObject bullet;
    [SerializeField] float moveStep = 1.2f;
    List<string> data;

    float delay = 0;
    int previousMicroButtonState = 1;

	void Update () 
    {
        if(CheckDelay()) SetPosition();
	    if (IsShootButtonClicked() && AmmoCounterController.GetCounterValue() > 0) Shoot();
        if (data != null) previousMicroButtonState = int.Parse(data[3].Substring(1, 1));
	    if (AmmoCounterController.GetCounterValue() == 0) TryReloading();
    }

    bool CheckDelay()
    {
        if (delay > 0.1f) { delay = 0; return true; }
        delay += Time.deltaTime; return false; 
    }

    bool IsShootButtonClicked()
    {
        return Input.GetMouseButtonDown(0) || IsMicroButtonClicked();
    }

    bool IsMicroButtonClicked()
    {
        return int.Parse(data[3].Substring(1, 1)) == 0 && previousMicroButtonState == 1;
    }

    void SetPosition()
    {
        GetDataFromFile();
        if (data == null) return;
        RotateWeapon();
        MakeJump();
    }

    void LookAround()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(weaponTransform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angleY = Mathf.Atan2(mousePos.y, -mousePos.x) * Mathf.Rad2Deg + 90;
        weaponTransform.rotation = Quaternion.Euler(new Vector3(0, angleY, 0));
    }

    void MoveHorizontally()
    {
        if (int.Parse(data[0]) > 2250) weaponTransform.position -= new Vector3(moveStep, 0, 0);
        if (int.Parse(data[0]) < -2250) weaponTransform.position += new Vector3(moveStep, 0, 0);
    }

    void RotateWeapon()
    {
        if (int.Parse(data[0]) > 2250) weaponTransform.Rotate(0, 1f, 0);
        if (int.Parse(data[0]) < -2250) weaponTransform.Rotate(0, -1f, 0);
    }

    void MakeJump()
    {
        if (int.Parse(data[2]) > 6500) StartCoroutine(ExecuteJump());
    }

    IEnumerator<WaitForSeconds> ExecuteJump()
    {
        for (int i = 0; i < 15; i++) {
            weaponTransform.position += new Vector3(0, 1f, 0);
            yield return new WaitForSeconds(0.0167f);
        }
        for (int i = 0; i < 15; i++) {
            weaponTransform.position += new Vector3(0, -1f, 0);
            yield return new WaitForSeconds(0.0167f);
        }
    }

    void Shoot()
    {
        MoveBullet();
        weaponSound.Play();
        AmmoCounterController.SetAmount(1);
    }

    void TryReloading() { if (int.Parse(data[1]) < -3000) AmmoCounterController.ClearCounter(); }

    void MoveBullet()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.SetParent(weaponTransform, false);
        newBullet.SetActive(true);
        newBullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 800f;
    }

    void GetDataFromFile()
    {
        try { data = System.IO.File.ReadAllLines((Application.dataPath + "/Resources/outputData.csv").Replace("/", "\\")).ToList(); }
        catch { return; }
    }
}
