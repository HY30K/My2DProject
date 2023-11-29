using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine _stateMachine; // 플레이어 상태머신
    protected Player _player;
    protected Rigidbody2D _rigidbody; // 편의성을 위해서 참조

    protected int _animBoolHash;
    // 이건 나중에 쓸거임. 지금은 안씀.
    protected readonly int _yVelocityHash = Animator.StringToHash("y_velocity");

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animationBoolName)
    {
        _player = player;
        _stateMachine = stateMachine;
        _animBoolHash = Animator.StringToHash(animationBoolName);
        _rigidbody = _player.RigidbodyCompo;
    }

    public virtual void Enter()
    {
        _player.AnimatorCompo.SetBool(_animBoolHash, true);
    }

    public virtual void UpdateState()
    {
        _player.AnimatorCompo.SetFloat(_yVelocityHash, _rigidbody.velocity.y);
    }

    public virtual void Exit()
    {
        _player.AnimatorCompo.SetBool(_animBoolHash, false);
    }
}
