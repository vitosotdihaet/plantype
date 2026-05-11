using TMPro;
using UnityEngine;

public class TypingField : MonoBehaviour {
    enum State {
        Bad,
        GoingOk,
        Match
    }

    private State state;
    private TMP_InputField playersInput;

    [Header("Text to match")]
    [SerializeField] private TMP_Text textToInput;

    [Header("Reaction to player")]
    [SerializeField] private GameObject reactionGroup;
    [SerializeField] private TMP_Text reactionTextBox;

    [Header("Text colors")]
    [SerializeField] private Color badColor;
    [SerializeField] private Color goingOkColor;
    [SerializeField] private Color matchColor;

    public void Awake() {
        playersInput = GetComponent<TMP_InputField>();
        playersInput.onValueChanged.AddListener(GrabFromInputField);
        playersInput.onEndEdit.AddListener(ActivateInputField);
    }

    public void Start() {
        ActivateInputField("");
        react();
    }

    public void ActivateInputField(string _) {
        playersInput.Select();
        playersInput.ActivateInputField();
    }

    public void GrabFromInputField(string _) {
        react();
    }

    private void react(){
        reactionGroup.SetActive(true);
        if (playersInput.text.Length == 0) {
            showInspirationalMessage();
            return;
        }

        if (textToInput.text.StartsWith(playersInput.text)) {
            if (playersInput.text.Length == textToInput.text.Length) {
                setTextMatches();
            } else {
                setTextIsGoingOk();
            }
        } else {
            setTextBad();
        }
    }

    private void setTextBad() {
        if (state == State.Bad) { return; }
        state = State.Bad;
        reactionTextBox.text = "bruh.";
        playersInput.textComponent.color = badColor;
    }

    private void setTextIsGoingOk() {
        reactionTextBox.text = "ok! " + playersInput.text.Length + "/" + textToInput.text.Length;
        if (state == State.GoingOk) { return; }
        state = State.GoingOk;
        playersInput.textComponent.color = goingOkColor;
    }

    private void setTextMatches() {
        if (state == State.Match) { return; }
        state = State.Match;
        reactionTextBox.text = "yay, you did it!";
        playersInput.textComponent.color = matchColor;
    }

    private void showInspirationalMessage() {
        reactionTextBox.text = "start typing, you lazy dog!";
    }
}
