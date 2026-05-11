using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class Typing : MonoBehaviour
{
    enum State
    {
        Default,
        Bad,
        GoingOk,
        Match,
        Inspire
    }

    private State state;

    private TMP_InputField playersInput;

    [Header("Text to match")]
    [SerializeField] private TMP_Text textToInput;

    [Header("Reaction to player")]
    [SerializeField] private GameObject reactionGroup;
    [SerializeField] private TMP_Text reactionTextBox;
    private ReactionAnimator reactionAnimator;

    [Header("Text colors")]
    [SerializeField] private Color badColor;
    [SerializeField] private Color goingOkColor;
    [SerializeField] private Color matchColor;

    private void Awake()
    {
        state = State.Default;
        playersInput = GetComponent<TMP_InputField>();
        playersInput.onValueChanged.AddListener(GrabFromInputField);
        playersInput.onEndEdit.AddListener(ActivateInputField);
        reactionGroup.SetActive(true);

        reactionAnimator = reactionTextBox.GetComponent<ReactionAnimator>();
    }

    public void Start()
    {
        ActivateInputField("");
        React();
    }

    public void ActivateInputField(string _)
    {
        playersInput.Select();
        playersInput.ActivateInputField();
    }

    public void GrabFromInputField(string _)
    {
        React();
    }

    private void React()
    {
        if (playersInput.text.Length == 0)
        {
            SetTextIsInsipre();
            return;
        }

        if (textToInput.text.StartsWith(playersInput.text))
        {
            if (playersInput.text.Length == textToInput.text.Length)
            {
                SetTextMatch();
            }
            else
            {
                SetTextIsGoingOk();
            }
        }
        else
        {
            SetTextBad();
        }
    }

    private void SetTextBad()
    {
        if (state == State.Bad) { return; }
        state = State.Bad;

        reactionTextBox.text = "damn, you are so bad at this";
        playersInput.textComponent.color = badColor;
        reactionAnimator.SetBad();
    }

    private void SetTextIsGoingOk()
    {
        if (state == State.GoingOk) { return; }
        state = State.GoingOk;

        reactionTextBox.text = "keep going!";
        playersInput.textComponent.color = goingOkColor;
        reactionAnimator.SetGoingOk();
    }

    private void SetTextMatch()
    {
        if (state == State.Match) { return; }
        state = State.Match;

        reactionTextBox.text = "yay, you did it!";
        playersInput.textComponent.color = matchColor;
        reactionAnimator.SetMatch();
    }

    private void SetTextIsInsipre()
    {
        if (state == State.Inspire) { return; }
        state = State.Inspire;

        reactionTextBox.text = "start typing, you lazy dog!";
        reactionAnimator.SetInspire();
    }
}
