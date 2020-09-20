using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePosition : MonoBehaviour
{
    //public GameObject Pointer;
    //private Vector3 Position;
    // Start is called before the first frame update

    public float gazeTime = 2f;
    private float timer;
    private bool gazeAt;

    void Start()
    {
       // Pointer = GameObject.FindGameObjectWithTag("ParticlePointer");
    }

    // Update is called once per frame
    void Update()
    {
        //ChangePosition();

        if (gazeAt)
        {
            timer += Time.deltaTime;

            Transform child = transform.GetChild(0);
            Vector3 newScale = new Vector3(timer / gazeTime, child.localScale.y, child.localScale.z);
            Vector3 newPosition = new Vector3(-0.5f +(timer /gazeTime) /2 , child.localPosition.y, child.localPosition.z);
            child.localScale = newScale;
            child.localPosition = newPosition;
            if(timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;
            }
        }
    }

    public void PointerEnter()
    {
        //ChangePosition();
        gazeAt = true;
    }


    public void PointerExit()
    {
        // ChangePosition();
        gazeAt = false;
    }

    //public void ChangePosition()
    //{
    //    Vector3 newPosition = Pointer.transform.position;
    //    newPosition.z = newPosition.z + 3f;
    //    newPosition.y = Pointer.transform.position.y;
    //    newPosition.x = Pointer.transform.position.x;
    //    gameObject.transform.position = newPosition;
    //}
    public void PointerDown()
    {

    }
    
}
