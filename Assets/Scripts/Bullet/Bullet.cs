using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (AudioManager.instance != null)
            {
                AudioSource.PlayClipAtPoint(
                    AudioManager.instance.bulletClip,
                    transform.position
                );
            }

            if (BulletManager.instance != null)
            {
                BulletManager.instance.AddBullets(bulletValue);
            }

            Destroy(gameObject);
        }
    }
}
