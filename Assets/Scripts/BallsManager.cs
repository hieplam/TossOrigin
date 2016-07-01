using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class BallsManager : MonoBehaviour
{

    public GameObject ball;
    public int maxBalls;
    public Text ScreenResolution;

    private Renderer ballRenderer;
    private float ballWidth;
    private float ballHeight;
    private Camera camera;
    private int currentExistBalls;
    private float cameraMaxHeight;
    private float cameraMaxWidth;

    void Start()
    {
        camera = Camera.main;
        ballRenderer = GetComponent<Renderer>();
        ballWidth = ball.GetComponent<Renderer>().bounds.size.x;
        ballHeight = ball.GetComponent<Renderer>().bounds.size.y;

        cameraMaxHeight = camera.orthographicSize;
        cameraMaxWidth = camera.orthographicSize * camera.aspect;

        Ball.ballDestroyed += () =>
        {
            currentExistBalls--;
        };

        for (var i = 0; i < maxBalls; i++)
        {
            RenderBall();
        }
        currentExistBalls = maxBalls;

    }

    void RenderBall()
    {
        var randomX = Random.Range(-cameraMaxWidth + ballWidth / 2, cameraMaxWidth - ballWidth / 2);
        var randomY = Random.Range(-cameraMaxHeight + ballHeight / 2, cameraMaxHeight - ballHeight / 2);
        var randomPosition = new Vector3(randomX, randomY, 0);

        InstantiateBall(randomPosition);
        currentExistBalls++;
    }

    GameObject InstantiateBall(Vector3 position)
    {
        return Instantiate(ball, position, Quaternion.identity) as GameObject;
    }

    void Update()
    {
        ScreenResolution.text = string.Format("Camera width:{0} - Camera height:{1}\nWidth:{2} - Height:{3}",
            Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize, Screen.width, Screen.height);
        if (currentExistBalls < maxBalls)
        {
            RenderBall();
        }
    }
}
