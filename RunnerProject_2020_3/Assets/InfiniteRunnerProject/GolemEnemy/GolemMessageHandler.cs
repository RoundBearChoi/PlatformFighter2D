using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class GolemMessageHandler : BaseMessageHandler
    {
        private Unit _unit = null;
        private bool _zeroHealthTriggered = false;

        public GolemMessageHandler(Unit unit)
        {
            _unit = unit;
        }

        public override void HandleMessages()
        {
            foreach(BaseMessage message in _listMessages)
            {
                if (message.MESSAGE_TYPE == MessageType.WINCE)
                {
                    _unit.unitData.listNextStates.Add(new Golem_Wincing(_unit, message.GetVector2Message(), message.GetUnitMessage()));
                }
                else if (message.MESSAGE_TYPE == MessageType.TAKE_DAMAGE)
                {
                    _unit.unitData.hp -= message.GetUnsignedIntMessage();

                    if (_unit.hpBar == null)
                    {
                        EnemyHPBar bar = GameObject.Instantiate(ResourceLoader.etcLoader.GetObj(etcType.HP_BAR)) as EnemyHPBar;
                        _unit.hpBar = bar;
                        bar.transform.parent = GameInitializer.current.GetStage().transform;
                        bar.SetOwnerUnit(_unit, new Vector2(-1.26f, 4.6f));
                    }
                }
                else if (message.MESSAGE_TYPE == MessageType.ZERO_HEALTH)
                {
                    if (!_zeroHealthTriggered)
                    {
                        _zeroHealthTriggered = true;
                        _unit.unitData.listNextStates.Add(new Golem_Death(_unit));
                    }

                    if (_unit.hpBar != null)
                    {
                        GameObject.Destroy(_unit.hpBar.gameObject);
                        _unit.hpBar = null;
                    }
                }
            }
        }
    }
}