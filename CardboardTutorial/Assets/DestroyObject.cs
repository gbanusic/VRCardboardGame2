using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    


    public float fillTime = 2f;
    private Color color;
    private Slider MySlider;
    private float timer;
    private bool gazeAt;
    private GameObject Parent;
    private GameObject GrandParent;
    private Coroutine fillBarRoutine;
    // Start is called before the first frame update
    void Start()
    {
        MySlider = GetComponent<Slider>();
        if (MySlider == null) Debug.Log("Please add a slider");
        color = new Color(255f, 10, 10);
        Changecolor(color);


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
        if (fillBarRoutine != null)
        {
            StopCoroutine(fillBarRoutine);
        }
        timer = 0f;
        MySlider.value = 0f;

    }
    private IEnumerator FillBar()
    {
        timer = 0f;
        while (timer < fillTime)
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
        Parent = transform.parent.gameObject;
        GrandParent = Parent.transform.parent.gameObject;
        Destroy(GrandParent);
        
    }
    public void Changecolor(Color color)
    {
        MySlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;
    }
}

