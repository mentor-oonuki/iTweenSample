using UnityEngine;
using System.Collections;

public class DropdownEvent : MonoBehaviour
{

    public void OnValueChanged(int result)
    {
        ITweenSample.EaseTypeNumber = result;
    }

}
