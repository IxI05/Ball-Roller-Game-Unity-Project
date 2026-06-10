using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Bullet Settings")]
    public Rigidbody bulletRigidbody;
    public float bulletSpeed = 100f;
    public float timeToLive = 5f;

    [Header("Shooting Control")]
    public float shootCooldown = 0.25f;
    private float lastShootTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryShoot();
        }
    }

    void TryShoot()
    {
        if (Time.time - lastShootTime < shootCooldown)
            return;

        if (BulletManager.instance == null)
            return;

        if (BulletManager.instance.GetBulletCount() <= 0)
        {
            if (AudioManager.instance != null)
                AudioManager.instance.PlaySFX(AudioManager.instance.OutofBulletsClip);

            return;
        }

        FireBullet();
        BulletManager.instance.AddBullets(-1);
        lastShootTime = Time.time;
    }

    void FireBullet()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlaySFX(AudioManager.instance.shootMusic);

        Rigidbody rb = Instantiate(bulletRigidbody, transform.position, transform.rotation);
        rb.linearVelocity = transform.forward * bulletSpeed;

        Destroy(rb.gameObject, timeToLive);
    }
}
