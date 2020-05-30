using UnityEngine;

[RequireComponent(typeof(Scissors))]
public class DragScissors : MonoBehaviour
{
    Vector2 previousPosition;
    Scissors scissors;

    private void Awake()
    {
        scissors = GetComponent<Scissors>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            var mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            var calculatedDelta = mousePos - previousPosition;
            previousPosition = Input.mousePosition;
            calculatedDelta /= 1500;

            var pos = transform.position;
            pos.x += calculatedDelta.x;
            pos.z += calculatedDelta.y;
            transform.position = pos;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CutFlower>()?.Cut(transform.position);
        scissors.Snip();
    }
}
