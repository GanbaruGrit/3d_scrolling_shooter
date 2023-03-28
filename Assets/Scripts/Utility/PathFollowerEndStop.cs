using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollowerEndStop : MonoBehaviour
{
    [SerializeField] public PathCreator pathCreator;
    [SerializeField] public EndOfPathInstruction endOfPathInstruction;
    [SerializeField] public float speed = 5;
    [SerializeField] bool rotateWithPath;
    float distanceTravelled;

    void Start()
    {
        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

    void Update()
    {
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            if (rotateWithPath) transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            
            if (distanceTravelled >= pathCreator.path.length)
            {
                pathCreator = null;
            }
        }
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}