using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedCombat.Events.Contracts
{

    public interface IEventPublisher
    {
        event GameTickHandler GameTick;
        void TriggerTick();
    }
}
