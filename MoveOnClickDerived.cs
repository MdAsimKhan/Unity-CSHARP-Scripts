using UnityEngine;
using UnityEngine.UI;

public class MoveOnClickDerived : MonoBehaviour
{
    public MoveOnClick moveOnClickScript;
    public LMNTSpeakOnClick lmnt;

    private void Start()
    {
        moveOnClickScript = FindObjectOfType<MoveOnClick>();
        lmnt = FindObjectOfType<LMNTSpeakOnClick>();

        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        lmnt.OnMouseDown();
        moveOnClickScript.OnMouseDown();
    }
}
