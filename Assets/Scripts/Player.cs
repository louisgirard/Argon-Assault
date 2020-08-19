using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("m/s")][SerializeField] float xSpeed = 4f;
    [Tooltip("m")] [SerializeField] float xRange = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xSpeed * xThrow * Time.deltaTime;
        float rawNewXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(rawNewXPosition, -xRange, xRange);

        transform.localPosition = new Vector3(clampedXPosition, transform.localPosition.y, transform.localPosition.z);

        print(xOffset);
    }
}
