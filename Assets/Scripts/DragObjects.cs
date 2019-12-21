using UnityEngine;

public class DragObjects : MonoBehaviour
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
    {//x=5<>x=-24   z=-3<>z=20 
        newPos = GetMouseWorldPos() + mOffset;
        if (newPos.x < -24f && newPos.z > 20f)
        {
            newPos.x = -24f;
            newPos.z = 20f;
        }
        else if (newPos.x < -24f && newPos.z < -3f)
        {
            newPos.x = -24f;
            newPos.z = -3;
        }
        else if (newPos.x > 5f && newPos.z > 20f)
        {
            newPos.x = 5f;
            newPos.z = 20f;
        }
        else if (newPos.x > 5f && newPos.z < -3f)
        {
            newPos.x = 5f;
            newPos.z = -3f;
        }        
        else if (newPos.x > 5f)
        {
            newPos.x = 5f;
        }
        else if (newPos.z > 20f)
        {
            newPos.z = 20f;
        }
        else if (newPos.z < -3f)
        {
            newPos.z = -3f;
        }
        else if (newPos.x < -24f)
        {
            newPos.x = -24f;
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