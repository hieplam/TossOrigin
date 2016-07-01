using System;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public delegate void BallDestroyed();
    public static event BallDestroyed ballDestroyed;
    public float initialScale;
    public float maxScale;
    public float speed;


    private Vector3 initialScaleVector;
    private Vector3 maxScaleVector;

    void Start()
    {
        initialScaleVector = new Vector3(initialScale, initialScale, 1);
        maxScaleVector = new Vector3(maxScale, maxScale, 1);
        transform.localScale = initialScaleVector;
    }

    void Update()
    {
        transform.localScale += new Vector3(0.01f, 0.01f, 0);
        if (transform.localScale.sqrMagnitude >= maxScaleVector.sqrMagnitude)
        {
            DestroyBall();
        }
    }
    void OnMouseDown()
    {
        DestroyBall();
    }

    private void DestroyBall()
    {
        Destroy(gameObject);
        if (ballDestroyed == null)
        {
            throw new NullReferenceException("event does not delegated");
        }

        ballDestroyed();
    }
}
