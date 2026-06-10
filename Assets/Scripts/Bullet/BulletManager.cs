using TMPro;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;
    public TextMeshProUGUI TxtBullet;
    private int totalBullets = 0;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
      
    }

    public void AddBullets(int amount)
    {
        totalBullets += amount;

        // Prevent negative values
        if (totalBullets < 0)
            totalBullets = 0;

        UpdateBulletUI();
    }

    public int GetBulletCount()
    {
        return totalBullets;
    }

    private void UpdateBulletUI()
    {
        TxtBullet.text = totalBullets.ToString();
    }


}
