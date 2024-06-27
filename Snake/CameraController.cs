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
        // ���������� ��������� ������
        sceneCamera.orthographic = true; // ���������� true, ���� ����������� ��������������� ������
        sceneCamera.orthographicSize = 7.775946f; // ���������� ������ �������� ��� ��������������� ������
    }
}
