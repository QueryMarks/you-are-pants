using UnityEngine;
using TMPro;
using System;

public class Signs : MonoBehaviour
{
    private TextMeshProUGUI tmp;

    private GameObject hpCon;
    private  RectTransform rect;
    [SerializeField] string signText = "Default Text";
    [SerializeField] Vector2 position = new Vector3(0f,1.5f);
    [SerializeField] float fontSize = 24;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log(transform.position);
        hpCon = new GameObject("Sign Text");
        hpCon.transform.SetParent(FindAnyObjectByType<Canvas>().transform,false);
        tmp = hpCon.AddComponent<TextMeshProUGUI>();

        tmp.text = signText;
        tmp.fontSize = fontSize;
        tmp.color = Color.white;
        tmp.transform.localPosition = new Vector3(transform.position.x,transform.position.y + 1.5f,transform.position.z);//new Vector3(0, 1.5f, 0);
        //Debug.Log(tmp.transform.position);
        
        tmp.transform.rotation = Quaternion.identity;
        tmp.alignment = TextAlignmentOptions.Center;

        rect = hpCon.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(300, 100);
        rect.anchoredPosition = Vector2.zero;
        rect.transform.localPosition =  new Vector3(transform.position.x,transform.position.y + 1.5f,transform.position.z);

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + new Vector3(position.x,position.y,0));

        rect.position = screenPos;

        //After more testing, it seems changing the Z position causes the effect!
        //Keeping this seperate as this is a really cool effect!
        //The text slides itself around the screen
        /*
        float x,y,z;
        x = position.x;
        y = position.y;
        z = position.z;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + new Vector3(x, y, z));

        rect.position = screenPos;
        */
    }
}
