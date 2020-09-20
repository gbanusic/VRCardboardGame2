using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class VRSlider : MonoBehaviour
{
    public GameObject Character;
    public float fillTime = 2f;
    private Color color;
    private Slider MySlider;
    private float timer;
    private bool gazeAt;
    private Coroutine fillBarRoutine;
    // Start is called before the first frame update
    void Start()
    {
        MySlider = GetComponent<Slider>();
        if (MySlider == null) Debug.Log("Please add a slider");
        color = new Color(255f, 10, 10);
        Changecolor(color);

        Character = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerEnter()
    {
        gazeAt = true;
        fillBarRoutine = StartCoroutine(FillBar());
    }

    public void PointerExit()
    {
        gazeAt = false;
        if(fillBarRoutine != null)
        {
            StopCoroutine(fillBarRoutine);
        }
        timer = 0f;
        MySlider.value = 0f;

    }
    private IEnumerator FillBar()
    {
        timer = 0f;
        while(timer < fillTime)
        {
            timer += Time.deltaTime;
            MySlider.value = timer / fillTime;

            yield return null;

            if (gazeAt)
                continue;
            timer = 0f;
            MySlider.value = 0f;
            yield break;
        }

        OnBarFilled();
    }

    private void OnBarFilled()
    {
        Debug.Log("Do something amazing!!");
        color = new Color(233f / 255f, 79f / 255f, 55f / 255f);
        Changecolor(color);
        Vector3 novaPozicija = MySlider.transform.position;
        Character.transform.position = novaPozicija; 
    }
    public void Changecolor(Color color)
    {
        MySlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;
    }
}


