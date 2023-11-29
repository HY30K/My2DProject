using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, string animationBoolName) : base(player, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        //���ٴ��� �����ؾ� ��������
        if (_player.IsGroundDetected())
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }

        //���� �����ϸ� �������̵� ���� ������

        //����ٰ��� Xinput�Է½� �¿� �����̴� ��� �߰��ؾ���
    }

    public override void Exit()
    {
        base.Exit();
    }
}
