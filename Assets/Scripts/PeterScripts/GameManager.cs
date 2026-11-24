using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float finalHealth;
    public int finalCombo;
    public float finalTime;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveResults(float health, int combo, float time)
    {
        finalHealth = health;
        finalCombo = combo;
        finalTime = time;
    }
}