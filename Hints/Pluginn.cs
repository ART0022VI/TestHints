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
        public override string Name => "Hello";
        public override Version Version => new Version(7, 7, 7);
        public TimeSpan TTime { get; set; }
        public override void Disable()
        {
            Qurre.Events.Round.Start += Stats;
        }

        public override void Enable()
        {
            Qurre.Events.Round.Start += Stats;
        }
        public void Stats()
        {
            Timing.RunCoroutine(Cycle(), "time");
        }
        public IEnumerator<float> Cycle()
        {
            Log.Info("перезапуск");
            int roundtime = 0;
            int pls = 0;
            int scp = 0;
            roundtime++;
            Log.Info($"игроков - {pls}, время раунда - {roundtime}, SCP - {scp}");
            foreach (Player pl in Player.List)
            {
                if (pl.Role == RoleType.Spectator)
                {
                    foreach (Player plll in Player.List)
                    {
                        pls++;
                        if (ScpList.Contains(plll.Role))
                        {
                            scp++;
                        }
                    }
                    foreach (Player pll in Player.List)
                    {
                        pll.ShowHint($"                                     <color=green> Сейчас {pls} игроков на сервер! </color>" +
                                    $"                                     \n <color=red> Сейчас {scp} сцп! </color>" +
                                    $"                                     \n <color=yello> Время ранунда - {Round.ElapsedTime} </color>", 10);
                    }
                }
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
    }
}
