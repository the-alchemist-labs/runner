using System.Collections;
using Unity.Cinemachine;
using Unity.Mathematics.Geometry;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float minFOV = 20f;
    [SerializeField] private float maxFOV = 120F;
    [SerializeField] private float zoomDuration = 1F;
    [SerializeField] private float zoomSpeedModifier = 5F;
    [SerializeField] private ParticleSystem speedUpparticleSystem;

    private CinemachineCamera _cc;
    
    void Awake()
    {
        _cc = GetComponent<CinemachineCamera>();
    }

    public void ChangeCameraFOV(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speedAmount));
        
        if (speedAmount > 0) speedUpparticleSystem.Play();
        else if (speedAmount < 0) speedUpparticleSystem.Stop();
    }

    private IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float cameraFOV = _cc.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(cameraFOV + (speedAmount * zoomSpeedModifier), minFOV, maxFOV);

        float elapsedTime = 0f;
        while (elapsedTime < zoomDuration)
        {
            elapsedTime += Time.deltaTime;
            _cc.Lens.FieldOfView = Mathf.Lerp(cameraFOV, targetFOV, elapsedTime / zoomDuration);
            yield return null;
        }
        
        _cc.Lens.FieldOfView = targetFOV;
    }
}