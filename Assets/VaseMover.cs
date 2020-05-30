using UnityEngine;

public class VaseMover : MonoBehaviour
{
    public LayerMask layer;
    [HideInInspector]
    public Transform movingVase;
    Vector3 initialPosition;
    Camera mainCam;

    void Start()
    {
        initialPosition = transform.localPosition;
        mainCam = Camera.main;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && movingVase != null)
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, layer))
            {
                var pos = movingVase.localPosition;
                pos.x = Mathf.Clamp(hit.point.x, ArrangeManager.rangeX.x, ArrangeManager.rangeX.y);
                movingVase.localPosition = pos;
            }
        }
    }
}
