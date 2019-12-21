using UnityEngine;
using System;

public class WallsSnapping : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag == "furniture")
        {
            if (other.gameObject.name.ToString().StartsWith("Sofa") || other.gameObject.name.ToString().StartsWith("ArmChair") || other.gameObject.name.ToString().StartsWith("Coffee_Table") || other.gameObject.name.ToString().StartsWith("Dining_Table"))
            {
                if (this.gameObject.name.ToString() == "Front")
                {
                    //Debug.Log(other.gameObject.name + " Entered! "+"Front");
                    other.transform.eulerAngles = new Vector3(other.transform.rotation.x, 180, other.transform.rotation.z);
                }
                else if (this.gameObject.name.ToString() == "Right")
                {
                    //Debug.Log(other.gameObject.name + " Entered! " + "Right");
                    other.transform.eulerAngles = new Vector3(other.transform.rotation.x, 90, other.transform.rotation.z);
                }
                else if (this.gameObject.name.ToString() == "Left")
                {
                    //Debug.Log(other.gameObject.name + " Entered! " + "Left");
                    other.transform.eulerAngles = new Vector3(other.transform.rotation.x, 270, other.transform.rotation.z);
                }
                else if (this.gameObject.name.ToString() == "Back")
                {
                    //Debug.Log(other.gameObject.name + " Entered! " + "Back");
                    other.transform.eulerAngles = new Vector3(other.transform.rotation.x, 0, other.transform.rotation.z);
                }
            }
        }        
    }
}