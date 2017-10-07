using Assets.Stroyboarder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStoryboardElement {

    IStoryBoardController controller { get; set; }

    bool Execute();

    bool ShouldWaitLonger();

    bool givesFeedback { get; set;  }
    
}
