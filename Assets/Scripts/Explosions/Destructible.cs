using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] GameObject objectPieces;
    GameObject objectPiecesClone;

    public void ChangeToPieces()
    {
        GameObject objectPiecesClone = Instantiate(objectPieces, transform.position, transform.rotation);
        Destroy(objectPiecesClone, 3);
    }
}
