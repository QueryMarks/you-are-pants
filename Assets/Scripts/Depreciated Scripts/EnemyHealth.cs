using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;

    private int currentHealth;

    private TextMeshProUGUI tmp;

    private GameObject hpCon;
    private  RectTransform rect;

    private Health stateHealth; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        

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

        Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.5f, 0));
        

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

        if(currentHealth <= 0)
        {
            die();
        }

    }

    private void die()
    {
        //I am dead lmao! Update your state stuff here? - ME
        LevelManager.updateDead();
        tmp.gameObject.SetActive(false);
        hpCon.SetActive(false);
        gameObject.SetActive(false);
    }
}
