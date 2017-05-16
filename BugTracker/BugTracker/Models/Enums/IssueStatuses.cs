using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models.Enums
{
    public enum IssueStatuses : byte
    {
    
        Open,
        CodeReview,
        ReOpened,
        Closed
    }
}