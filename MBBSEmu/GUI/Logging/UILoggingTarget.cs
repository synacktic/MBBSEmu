using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NLog;
using NLog.Targets;
using System.Text;
using NLog.Common;

namespace MBBSEmu.GUI.Logging
{
    [Target("UILoggingTarget")]
    public sealed class UILoggingTarget : TargetWithLayout
    {
        public List<string> Log = new();

        public UILoggingTarget(string name)
        {
            this.Name = name;
        }

      
        protected override void Write(LogEventInfo logEvent)
        {
            Log.Add(RenderLogEvent(Layout, logEvent));
        }
        
    }
}
