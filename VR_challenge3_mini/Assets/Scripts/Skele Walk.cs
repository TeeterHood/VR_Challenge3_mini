using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleWalk : MonoBehaviour
{
    // the room the skeleton is in will have four waypoints that the skeleton will walk to
    // the skeleton will walk to each waypoint in order, then loop back to the first waypoint

    // reference to empty game objects that the skeleton will walk to
    public Transform[] waypoints;

    // the current waypoint the skeleton is walking to
    private int currentWaypoint = 0; // 0, 1, 2, 3

    // speed of the skeleton
    public float speed = 2.0f;

    void FixedUpdate()
    {
        // Move the skeleton towards the current waypoint
        MoveTowardsWaypoint();
    }

    private void MoveTowardsWaypoint()
    {
        // Calculate the direction to the current waypoint
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;
        direction.y = 0; // Lock the Y axis
        direction.Normalize();
    
        // Calculate the rotation towards the waypoint
        Quaternion targetRotation = Quaternion.LookRotation(direction);
    
        // Gradually rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    
        // Move the skeleton towards the waypoint
        transform.position += transform.forward * speed * Time.deltaTime;
    
        // Check if the skeleton has reached the waypoint
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), 
                             new Vector3(waypoints[currentWaypoint].position.x, 0, waypoints[currentWaypoint].position.z)) < 0.5f)
        {
            // Increment the current waypoint
            currentWaypoint++;
    
            // If the current waypoint is greater than the number of waypoints
            if (currentWaypoint >= waypoints.Length)
            {
                // Reset the current waypoint to 0
                currentWaypoint = 0;
            }
        }
    }
}
