using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ReactionAnimator : MonoBehaviour
{
    private static readonly int BadHash = Animator.StringToHash("Bad");
    private static readonly int MatchHash = Animator.StringToHash("Match");
    private static readonly int GoingOkHash = Animator.StringToHash("GoingOk");
    private static readonly int InspireHash = Animator.StringToHash("Inspire");

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // public void SetBadParameter(bool v)
    // {
    //     animator.SetBool(BadHash, v);
    // }

    // public void SetGoingOkParameter(bool v)
    // {
    //     animator.SetBool(GoingOkHash, v);
    // }

    // public void SetMatchParameter(bool v)
    // {
    //     animator.SetBool(MatchHash, v);
    // }

    // public void SetInspireParameter(bool v)
    // {
    //     animator.SetBool(InspireHash, v);
    // }

    public void SetBad()
    {
        animator.SetBool(BadHash, true);
        animator.SetBool(GoingOkHash, false);
        animator.SetBool(MatchHash, false);
        animator.SetBool(InspireHash, false);
    }

    public void SetGoingOk()
    {
        animator.SetBool(BadHash, false);
        animator.SetBool(GoingOkHash, true);
        animator.SetBool(MatchHash, false);
        animator.SetBool(InspireHash, false);
    }

    public void SetMatch()
    {
        animator.SetBool(BadHash, false);
        animator.SetBool(GoingOkHash, false);
        animator.SetBool(MatchHash, true);
        animator.SetBool(InspireHash, false);
    }

    public void SetInspire()
    {
        animator.SetBool(BadHash, false);
        animator.SetBool(GoingOkHash, false);
        animator.SetBool(MatchHash, false);
        animator.SetBool(InspireHash, true);
    }
}
