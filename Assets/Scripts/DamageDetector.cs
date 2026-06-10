using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    public string targetTag = "bullet";
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(targetTag))
            return;

       
        if (explosionPrefab != null)
        {
            Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );
        }

       
        if (AudioManager.instance != null)
        {
            AudioSource.PlayClipAtPoint(
                AudioManager.instance.destroyClip,
                transform.position
            );
        }

        Destroy(collision.gameObject); // bullet
        Destroy(gameObject);           // obstacle
    }
}
