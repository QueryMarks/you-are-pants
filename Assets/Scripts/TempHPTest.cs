using UnityEngine;

public class TempHPTest : MonoBehaviour
{

    public int health = 3;

    public int comboMeter = 12;

    private UI_Script ui;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ui = GetComponent<UI_Script>();

        if(ui == null)
        {
            Debug.LogError("Failed to find UI Script!");
        }
        else
        {
            ui.UpdateHP(health);
            ui.UpdateCombo(comboMeter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            health++;
            comboMeter++;
            ui.UpdateHP(health);
            ui.UpdateCombo(comboMeter);
        }
    }
}
