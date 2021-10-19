using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class tempRunner_Death : UnitState
    {
        public tempRunner_Death(Unit unit)
        {
            Debugger.Log("runner is dead");
            _ownerUnit = unit;

            _listMatchingSpriteTypes.Add(SpriteType.RUNNER_TEMP_DEATH);
        }

        public override void OnEnter()
        {
            BaseMessage message = new UIMessage(MessageType.RUNNER_IS_DEAD);
            message.Register();

            _ownerUnit.transform.position = _ownerUnit.transform.position + (Vector3.back * 1f);
            _ownerUnit.unitData.rigidBody2D.velocity = new Vector3(0f, 6f, 0f);
            _ownerUnit.unitData.boxCollider2D.enabled = false;
        }

        public override void OnFixedUpdate()
        {
            if (_ownerUnit.transform.position.y <= -20f)
            {
                _ownerUnit.unitData.rigidBody2D.Sleep();
            }
        }
    }
}