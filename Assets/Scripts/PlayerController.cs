using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("m/s")][SerializeField] float speed = 10f;
    [Tooltip("m")] [SerializeField] float xRange = 4.5f;
    [Tooltip("m")] [SerializeField] float yRange = 2f;

    [Header("Screen Position")]
    [SerializeField] float positionPicthFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control Throw")]
    [SerializeField] float controlPicthFactor = -20f;
    [SerializeField] float controlRollFactor = -10f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = speed * xThrow * Time.deltaTime;
        float yOffset = speed * yThrow * Time.deltaTime;

        float rawNewXPosition = transform.localPosition.x + xOffset;
        float rawNewYPosition = transform.localPosition.y + yOffset;

        float clampedXPosition = Mathf.Clamp(rawNewXPosition, -xRange, xRange);
        float clampedYPosition = Mathf.Clamp(rawNewYPosition, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPosition, clampedYPosition, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPicthFactor;
        float pitchDueToControl = yThrow * controlPicthFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void OnPlayerDeath()
    {
        isControlEnabled = false;
    }
}
