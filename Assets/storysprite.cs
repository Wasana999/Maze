using UnityEngine;

public class storysprite : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public GameObject story;

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            story.SetActive(true);
            Debug.Log("Press E");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            story.SetActive(false);
            Debug.Log("Press E");
        }
    }

}
