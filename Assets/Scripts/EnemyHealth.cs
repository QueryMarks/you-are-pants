using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;

    private int currentHealth;

    private TextMeshProUGUI tmp;

    private GameObject hpCon;
    private  RectTransform rect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;

        hpCon = new GameObject("Enemy HP");
        
        hpCon.transform.SetParent(Object.FindAnyObjectByType<Canvas>().transform,false);
        
        tmp = hpCon.AddComponent<TextMeshProUGUI>();


        tmp.text = currentHealth.ToString() + "/" + maxHealth.ToString();

        tmp.fontSize = 36;
        tmp.color = Color.white;
        tmp.transform.localPosition = new Vector3(0, 1.5f, 0);
        tmp.transform.rotation = Quaternion.identity;
        tmp.alignment = TextAlignmentOptions.Center;

        rect = hpCon.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(300, 100);
        rect.anchoredPosition = Vector2.zero;

        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.5f, 0));

        rect.position = screenPos;

        if(Input.GetKeyDown(KeyCode.M))
        {
            updateHealth();
        }
    }

    void updateHealth()
    {
        currentHealth--;

        tmp.text = currentHealth.ToString() + "/" + maxHealth.ToString();

    }
}
