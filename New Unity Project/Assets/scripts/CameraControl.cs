
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("跟隨目標")]
    public Transform target;
    [Header("跟隨速度"),Range(0f,100f)]
    public float speed = 1.5f;
    // Update is called once per frame
    private void Track()
    {
        float limitY = Mathf.Clamp(target.position.y, -1f, 3f);

        Vector3 taretPos = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, taretPos, 0.3f * speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        Track();
    }
}
