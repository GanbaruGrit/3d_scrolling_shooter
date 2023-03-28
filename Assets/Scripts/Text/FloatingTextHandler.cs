using UnityEngine;
using TMPro;

public class FloatingTextHandler : MonoBehaviour
{
    [SerializeField] Enemy enemyScript;

    [SerializeField] float xPos;
    [SerializeField] float yPos;
    [SerializeField] float zPos;

    [SerializeField] TMP_Text scoreText;

    void Start()
    {
        //transform.localPosition = transform.localPosition + new Vector3(xPos, yPos, zPos);
        Destroy(gameObject, 3f);
        scoreText.SetText(enemyScript.pointValue.ToString());
    }
}
