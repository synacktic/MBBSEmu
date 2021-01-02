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

        protected override void Write(IList<AsyncLogEventInfo> logEvents)
        {
            base.Write(logEvents);
        }

        protected override void WriteAsyncThreadSafe(AsyncLogEventInfo logEvent)
        {
            base.WriteAsyncThreadSafe(logEvent);
        }

        protected override void WriteAsyncThreadSafe(IList<AsyncLogEventInfo> logEvents)
        {
            base.WriteAsyncThreadSafe(logEvents);
        }
    }
}
