using UnityEngine;

public class SoccerNet : MonoBehaviour
{
    public int teamNumber = 0;

    // Right Now, we're keeping score on the net...
    // This might not how we'll do this later,
    public int score = 0;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Net Found: " + other.gameObject.name);


        // Validate that what you got is a soccer ball 
        SoccerBall sb = other.gameObject.GetComponent<SoccerBall>();
        if (sb)
        {
          
            score++;
            sb.Reset();
            Debug.Log("Ball Scored! Team " + teamNumber + "@" + score);
        }
    }
   
}
