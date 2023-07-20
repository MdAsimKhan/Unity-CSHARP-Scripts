using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOnClick : MonoBehaviour
{
    public Button button;
    public GameObject target;
    public GameObject[] toDisable;

    void Start()
    {
        if(!button)
        {
            button = gameObject.GetComponent<Button>();
        }

        button.onClick.AddListener(ToggleActiveState);
    }

    private void ToggleActiveState()
    {
        for(int i = 0; i < toDisable.Length; i++)
        {
            if(toDisable[i] != target) toDisable[i].SetActive(false);
            else toDisable[i].SetActive(!target.activeSelf);
        }
    }
}
