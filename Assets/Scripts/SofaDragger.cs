using UnityEngine;

public class SofaDragger : MonoBehaviour
{
    Vector3 mOffset;
    float mZCoord;
    Vector3 newPos;

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        newPos = GetMouseWorldPos() + mOffset;

        if(this.gameObject.transform.eulerAngles.y==0  ||  this.gameObject.transform.eulerAngles.y == 180)
        {
            //x{0.6f><-19.5f} z{-5f<>25f}
            if (newPos.x < -19.5f && newPos.z > 25f)
            {
                newPos.x = -19.5f;
                newPos.z = 25f;
            }
            else if (newPos.x < -19.5f && newPos.z < -5f)
            {
                newPos.x = -19.5f;
                newPos.z = -5f;
            }
            else if (newPos.x > 0.6f && newPos.z > 25f)
            {
                newPos.x = 0.6f;
                newPos.z = 25f;
            }
            else if (newPos.x > 0.6f && newPos.z < -5f)
            {
                newPos.x = 0.6f;
                newPos.z = -5f;
            }
            else if (newPos.x > 0.6f)
            {
                newPos.x = 0.6f;
            }
            else if (newPos.z > 25f)
            {
                newPos.z = 25f;
            }
            else if (newPos.z < -5f)
            {
                newPos.z = -5f;
            }
            else if (newPos.x < -19.5f)
            {
                newPos.x = -19.5f;
            }
        }
        else if(this.gameObject.transform.eulerAngles.y == 90.00001 || this.gameObject.transform.eulerAngles.y == 270 || this.gameObject.transform.eulerAngles.y == -90.00001 || this.transform.eulerAngles.y == 90 || this.gameObject.transform.eulerAngles.y == -90)
        {
            //x{6.8f><-25.67f} z{-1.5f><18f}
            if (newPos.x < -25.67f && newPos.z > 18f)
            {
                newPos.x = -25.67f;
                newPos.z = 18f;
            }
            else if (newPos.x < -25.67f && newPos.z < -1.5f)
            {
                newPos.x = -25.67f;
                newPos.z = -1.5f;
            }
            else if (newPos.x > 6.8f && newPos.z > 18f)
            {
                newPos.x = 6.8f;
                newPos.z = 18f;
            }
            else if (newPos.x > 6.8f && newPos.z < -1.5f)
            {
                newPos.x = 6.8f;
                newPos.z = -1.5f;
            }
            else if (newPos.x > 6.8f)
            {
                newPos.x = 6.8f;
            }
            else if (newPos.z > 18f)
            {
                newPos.z = 18f;
            }
            else if (newPos.z < -1.5f)
            {
                newPos.z = -1.5f;
            }
            else if (newPos.x < -25.67f)
            {
                newPos.x = -25.67f;
            }
        }
        else
        {
            Debug.Log("Undefined angle found! " + this.gameObject.transform.eulerAngles.y);
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