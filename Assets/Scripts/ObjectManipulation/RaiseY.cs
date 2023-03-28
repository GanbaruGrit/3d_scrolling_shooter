using UnityEngine;

public class RaiseY : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float distanceToTravel = 20f;
    bool reachedTarget;
    public GameObject objToMove;
    Vector3 originalPos;
    float transformPosY;

    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    void Update()
    {
        if (transform.position.y <= distanceToTravel)
        {
            DoRaise();
            
        } else if (originalPos.y <= transform.position.y)
        {
            DoReturn();
        }
    }

    void DoRaise()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void DoReturn()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }
}
