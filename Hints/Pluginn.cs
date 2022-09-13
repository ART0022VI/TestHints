using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qurre;
using Qurre.API;


namespace Hints
{
    public class Pluginn : Plugin
    {
        public override string Developer => "ГIеJIbмeнь#3519";
        public override string Name => "Hello";
        public override Version Version => new Version(7, 7, 7);
        public override void Disable()
        {
            Qurre.Events.Round.Start -= Stats;
        }

        public override void Enable()
        {
            Qurre.Events.Round.Start += Stats;
        }   
        public void Stats()
        {
            int pls = 0;
            int scp = 0;
            foreach (Player pl in Player.List)
            {
                pls++;
                if (ScpList.Contains(pl.Role))
                {
                    scp++;
                }
            }
            foreach (Player pl in Player.List)
            {
                pl.ShowHint($"Сейчас {pls} игроков на сервер!" + $"\n Сейчас {scp} сцп!", 10);
            }
        }
        public List<RoleType> ScpList = new List<RoleType>()
        {
            RoleType.Scp173,
            RoleType.Scp106,
            RoleType.Scp049,
            RoleType.Scp096,
            RoleType.Scp93953,
            RoleType.Scp93989,
            RoleType.Scp079
        };
    }
}
