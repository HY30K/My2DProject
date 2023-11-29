using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, string animationBoolName) : base(player, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // 벽에 붙었을 떄 점프를 할 수 있어야 해
        _player.PlayerInput.JumpEvent += HandleJumpEvent;
    }

    private void HandleJumpEvent()
    {
        // 그냥 월점프 상태로 변경만 해주면 된다.
        _stateMachine.ChangeState(PlayerStateEnum.WallJump);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        float xInput = _player.PlayerInput.XInput;
        float yInput = _player.PlayerInput.YInput;

        if (yInput < 0)
        {
            _player.SetVelocity(0, _rigidbody.velocity.y);
        }
        else
        {
            _player.SetVelocity(0, _rigidbody.velocity.y * 0.6f);
        }

        // 다른 방향으로 방향키를 눌렀다면 (facingDirection과 다른 방향으로 눌렀다면)
        // Idle상태로 전환하는거 

        if (Mathf.Abs(_player.FacingDirection + xInput) < 0.5f)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Fall);
        }

        // 땅에 닿았다면
        // Idle상태로 전환하는거

        if (_player.IsGroundDetected())
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
        _player.PlayerInput.JumpEvent -= HandleJumpEvent;
    }
}
