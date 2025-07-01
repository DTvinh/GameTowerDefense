using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 dragOrigin;
    float targetFieldOfView = 6;
    public Camera cam;
    [SerializeField] private float camSpeed;
    public PolygonCollider2D poly;
    Vector2 minLimit, maxLimit;


    public float shakeTime = 0.5f;

    public CinemachineVirtualCamera virtualCamera;
    public CinemachineConfiner2D config2D;
    void Start()
    {
        Observer.AddListener(CONSTANT.CAMERA_SHAHKE, EffectShake);

        if (poly != null)
        {
            Bounds bounds = poly.bounds;
            minLimit = bounds.min;
            maxLimit = bounds.max;


        }
    }
    // Update is called once per frame
    void Update()
    {
        PanCamera();
        hendleZoomCam();
        ShakeCamera();
    }
    private void PanCamera()
    {

        if (Input.GetMouseButtonDown(1))
        {
            // dragOrigin=this.transform.position;
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log(dragOrigin);

        }
        if (Input.GetMouseButton(1))
        {
            // dragOrigin=this.transform.position;
            // Debug.Log("giu mouse");
            Vector3 defference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            transform.position = ClampCamera(transform.position + defference * camSpeed * Time.deltaTime);
            // transform.position += defference * camSpeed * Time.deltaTime;
            // cam.transform.position = transform.position;

        }

        // if()
    }


    private void hendleZoomCam()
    {
        if (Input.mouseScrollDelta.y == 0) return;

        if (Input.mouseScrollDelta.y < 0 && targetFieldOfView <= 14)
        {

            targetFieldOfView += 1;

        }
        if (Input.mouseScrollDelta.y > 0 && targetFieldOfView >= 6)
        {

            targetFieldOfView -= 1;

        }

        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(cam.orthographicSize, targetFieldOfView, Time.deltaTime * 30);
        config2D.InvalidateCache();


    }


    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = minLimit.x + camWidth;
        float maxX = maxLimit.x - camWidth;
        float minY = minLimit.y + camHeight;
        float maxY = maxLimit.y - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, -10);
    }

    private void EffectShake(object[] datas)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 4f;
        shakeTime = 0.1f;


    }

    public void ShakeCamera()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
            if (shakeTime <= 0)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

            }
        }
    }








}
