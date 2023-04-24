using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextBasedCombat.Events.Contracts;

namespace TextBasedCombat.Events
{
    
    public class EventPublisher : IEventPublisher
    {
        public event GameTickHandler GameTick;

        protected virtual void OnGameTick() 
        {
            GameTick?.Invoke();
        }

        public void TriggerTick()
        {
            OnGameTick();
        }
    }
}
