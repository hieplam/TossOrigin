using UnityEngine;
using System.Collections;

public class BackgroundGenerate : MonoBehaviour
{
    public GameObject backgroundSprite;

    private Camera camera;
    private float cameraMaxHeight;
    private float cameraMaxWidth;
    private GameObject Background;
    private Vector3 backgroundSize;
    // Awake always called before start function
    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        camera = Camera.main;
        cameraMaxHeight = camera.orthographicSize;
        cameraMaxWidth = camera.orthographicSize * camera.aspect;
        Background = new GameObject("Background");
        backgroundSize = backgroundSprite.GetComponent<Renderer>().bounds.size;

        for (var x = -cameraMaxWidth + backgroundSize.x / 2; x < cameraMaxWidth; x++)
            for (var y = -cameraMaxHeight + backgroundSize.y / 2; y < cameraMaxHeight; y++)
            {
                var instance = Instantiate(backgroundSprite, new Vector3(x, y, 0.0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(Background.transform);
            }
    }
}
