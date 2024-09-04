using Cinemachine;
using UnityEngine;

public class CameraController:MonoBehaviour{
    private CinemachineVirtualCamera _camera;
    private void Awake(){
        _camera = FindAnyObjectByType<CinemachineVirtualCamera>();
    }
    public void Shake(float Intensity){
        var noise = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = Intensity;
    }
}
