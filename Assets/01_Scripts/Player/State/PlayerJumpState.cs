using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animationBoolName) : base(player, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.SetVelocity(_rigidbody.velocity.x, _player.jumpForece, true);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        // 점프중에 좌우로 움직이길 원한다면 여기다 뭔가 코딩해야해

        if (_rigidbody.velocity.y < 0)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
