using System.Collections;
using System.Collections.Generic;

namespace LockStep
{
    public class BattleUnitSystem
    {
        PlayerUnit player;
        public BattleUnitSystem()
        {
            player = new PlayerUnit();
        }

        public void UpdateLogic(FrameData data)
        {
            if (data != null)
            { 
                player.Input(data.op);
            }
        }

        public void UpdateRender(float interpolation)
        {
            player.UpdateRender(interpolation);
        }

        public void RecordLastPos()
        {
            player.RecordLastPos();
        }
    }
}

