using UnityEngine;

public class SmallObjectsDragger : MonoBehaviour
{
    Vector3 mOffset;
    float mZCoord;
    Transform initialPos;
    Vector3 newPos;

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {//x=18<x<x=-18   z=-19<>z=16
        newPos = GetMouseWorldPos() + mOffset;
        if (newPos.x < -27f && newPos.z > 26f)
        {
            newPos.x = -27f;
            newPos.z = 26f;
        }
        else if (newPos.x < -27f && newPos.z < -9.5f)
        {
            newPos.x = -27f;
            newPos.z = -9.5f;
        }
        else if (newPos.x > 8.5f && newPos.z > 26f)
        {
            newPos.x = 8.5f;
            newPos.z = 26f;
        }
        else if (newPos.x > 8.5f && newPos.z < -9.5f)
        {
            newPos.x = 8.5f;
            newPos.z = -9.5f;
        }
        else if (newPos.x > 8.5f)
        {
            newPos.x = 8.5f;
        }
        else if (newPos.z > 26f)
        {
            newPos.z = 26f;
        }
        else if (newPos.z < -9.5f)
        {
            newPos.z = -9.5f;
        }
        else if (newPos.x < -27f)
        {
            newPos.x = -27f;
        }
        this.transform.position = new Vector3(newPos.x, -10, newPos.z);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
