using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballProjekt
{
    public interface IPlayable
    {
        void ScoreGoal();
        void GiveAssist();
        void TreatInjury();
    }

}
