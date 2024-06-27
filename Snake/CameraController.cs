using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public Camera sceneCamera;

    void Start()
    {
        if (sceneCamera != null)
        {
            SetupCamera();
        }
    }

    void SetupCamera()
    {
        // Установите параметры камеры
        sceneCamera.orthographic = true; // Установите true, если используете ортографическую камеру
        sceneCamera.orthographicSize = 7.775946f; // Установите нужное значение для ортографической камеры
    }
}
