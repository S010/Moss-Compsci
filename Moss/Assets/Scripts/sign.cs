using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sign : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogBox; // The dialog box that will be on screen
    public Text dialogText; // The text of the dialog box that is displayed
    public string dialog; // The text that is inputted in the object inspector
    public bool playerInRange; // If the player is in range or not
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange) // This checks if the player has pressed the button and if the player is in range
        {
            if(dialogBox.activeInHierarchy)//This checks if the dialogbox is aleady on the screen
            {
                dialogBox.SetActive(false);//Makes the dialogbox go away
            }else// If it isnt on screen
            {
               dialogBox.SetActive(true);//Make the dialog box appear
               dialogText.text = dialog; // Set the text to the inputted text
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)  // Checks if an object is in the collsion box of the object , then passes the object through via the parameter other
    {
        if(other.CompareTag("Player")) // Checks  if the tag of the object is the player
        {
            playerInRange = true; // Changes the boolean to True , so the player is in range
        }    
    }
    private void OnTriggerExit2D(Collider2D other) // Checks if an object is not in the collsion box of the object, then passes the object through via the parameter other
    {
        if(other.CompareTag("Player")) // Checks if the tag of the object is the player
        {
            playerInRange = false; // Changes the boolean to False , so the player is not in range
            dialogBox.SetActive(false); // Makes the dialog box go away when the player walks away from the object
        }

    }
}
