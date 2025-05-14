using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float resetPositionX = -20f; 
    public float startPositionX = 20f;  

    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x < resetPositionX)
        {
            Vector3 newPos = transform.position;
            newPos.x = startPositionX;
            transform.position = newPos;
        }
    }
}
