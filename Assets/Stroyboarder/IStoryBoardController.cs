using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Stroyboarder
{

    public interface IStoryBoardController
    {
        List<IStoryboardElement> elements { get; set; }

        void StartController();

        void StopController();
    }
}
