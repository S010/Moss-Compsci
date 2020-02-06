using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private cameraMovement cam;
    // Start is called before the first frame update
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    void Start()
    {
        cam = Camera.main.GetComponent<cameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            cam.minPos += cameraChange;
            cam.maxPos += cameraChange;
            other.transform.position += playerChange;
            if (needText) //show name of place
            {
                StartCoroutine(placeNameCo());
            }
        }
    }
    private IEnumerator placeNameCo() //Place Name coRoutine
    {
        text.SetActive(true);//Show text
        placeText.text = placeName;//Change Text
        yield return new WaitForSeconds(3f);//Wait
        text.SetActive(false);//Delete
    }
}

