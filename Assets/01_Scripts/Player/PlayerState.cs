using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine _stateMachine; // �÷��̾� ���¸ӽ�
    protected Player _player;
    protected Rigidbody2D _rigidbody; // ���Ǽ��� ���ؼ� ����

    protected int _animBoolHash;
    // �̰� ���߿� ������. ������ �Ⱦ�.
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