using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextBasedCombat.World;
using TextBasedCombat.Items;
using TextBasedCombat.System;
using TextBasedCombat.Events.Contracts;
using TextBasedCombat.Events;

namespace TextBasedCombat
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IEventPublisher publisher = new EventPublisher();
            var system = new Main(publisher);
            system.Main_Thread();



        }

        

    }
}
