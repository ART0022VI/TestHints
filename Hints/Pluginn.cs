using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEC;
using Qurre;
using Qurre.API;
using Qurre.API.Events;

namespace Hints
{
    public class Pluginn : Plugin
    {
        public override string Developer => "ГIеJIbмeнь#3519";
        public override string Name => "Hints";
        public override Version Version => new Version(1, 0, 0);
        public TimeSpan TTime { get; set; }
        public static int pls = 0;
        public static int scp = 0;
        public override void Disable()
        {
            Qurre.Events.Round.Start += Stats;
            Qurre.Events.Player.Join += OnJoin;
            Qurre.Events.Player.Leave += OnLeave;
        }

        public override void Enable()
        {
            Qurre.Events.Round.Start += Stats;
            Qurre.Events.Player.Join -= OnJoin;
            Qurre.Events.Player.Leave -= OnLeave;
        }   
        public void Stats()
        {
            Timing.RunCoroutine(Cycle(), "time");
            foreach (Player plll in Player.List)
            {
                pls++;
                if (ScpList.Contains(plll.Role))
                {
                    scp++;
                }
            }
        }
        public IEnumerator<float> Cycle()
        {
            TTime = new TimeSpan(0, 0, 0);
            int roundtime = 0;
            while (!Round.Ended)
            {
                foreach (Player pl in Player.List)
                {
                    if (pl.Role == RoleType.Spectator)
                    {
                        foreach (Player pll in Player.List)
                        {
                            pll.ShowHint($"<align=right><color=green> Онлайн - {pls}</color></align>" +
                                        $"\n <align=right><color=red> Сейчас {scp} СЦП </color></align>" +
                                        $"\n <align=right><color=yellow> Время ранунда - {TTime} </color></align>", 1);
                        }
                    }
                }
                TTime += TimeSpan.FromSeconds(1f);
                yield return Timing.WaitForSeconds(1f);
            }
            yield return Timing.WaitForSeconds(1f);
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
        public void OnJoin(JoinEvent ev) => pls++;
        public void OnLeave(LeaveEvent ev) => pls--;
    }
}
