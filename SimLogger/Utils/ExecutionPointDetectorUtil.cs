using System.Diagnostics;
using System.Reflection;

namespace SimLogger.Utils
{
    public class ExecutionPointDetectorUtil
    {
        const int SkipFrameCount = 1;
        public static string GetClassFullName()
        {
            var stackTrace = new StackTrace(SkipFrameCount, false);
            foreach (var frame in stackTrace.GetFrames())
            {
                var className = TakeClassNameFromStackFrame(frame);
                if (!string.IsNullOrEmpty(className))
                {
                    return className;
                }
            }

            return null;
        }

        private static string TakeClassNameFromStackFrame(StackFrame stackFrame)
        {
            var method = stackFrame.GetMethod();
            if (method != null)
            {
                var className = GetMethodClassNameFromStackFrame(method) ?? method.Name;
                if (!string.IsNullOrEmpty(className))
                {
                    return className;
                }
            }

            return string.Empty;
        }

        private static string GetMethodClassNameFromStackFrame(MethodBase method)
        {
            return method.DeclaringType?.FullName;
        }
    }
}
