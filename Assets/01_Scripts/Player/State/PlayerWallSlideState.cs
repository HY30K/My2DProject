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
        // ���� �پ��� �� ������ �� �� �־�� ��
        _player.PlayerInput.JumpEvent += HandleJumpEvent;
    }

    private void HandleJumpEvent()
    {
        // �׳� ������ ���·� ���游 ���ָ� �ȴ�.
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

        // �ٸ� �������� ����Ű�� �����ٸ� (facingDirection�� �ٸ� �������� �����ٸ�)
        // Idle���·� ��ȯ�ϴ°� 

        if (Mathf.Abs(_player.FacingDirection + xInput) < 0.5f)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Fall);
        }

        // ���� ��Ҵٸ�
        // Idle���·� ��ȯ�ϴ°�

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
