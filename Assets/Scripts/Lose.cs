using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
        {
                ScoreManager.instance.SaveFinalScore();
                SceneManager.LoadScene("GameOver");
            }
        }
}
