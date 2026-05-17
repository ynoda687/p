using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject[] weapons;      // 1〜5
    public Transform firePoint;       // カメラの前 or 銃口
    public GameObject bulletPrefab;
    public float bulletSpeed = 40f;

    int currentIndex = 0;

    void Start()
    {
        UpdateWeaponActive();
    }

    public void SetWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length) return;
        currentIndex = index;
        UpdateWeaponActive();
    }

    void UpdateWeaponActive()
    {
        for (int i = 0; i < weapons.Length; i++)
            weapons[i].SetActive(i == currentIndex);
    }

    public void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject bullet = Object.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }
}

