using System;
using System.Threading;

namespace MagicBox
{
    /// <summary>
    /// 提供了方法调度的超时管理
    /// </summary>
    public class Timeout
    {
        /// <summary>
        /// 指定一个时间尝试完成一个任务
        /// </summary>
        /// <param name="timeSpan">执行任务的限定时间</param> 
        /// <param name="action">执行任务的委托</param>
        /// <returns>任务在规定时间内完成返回true，否则为false</returns>
        public bool DoWithTimeout(TimeSpan timeSpan, Action action)
        {
            if (action == null)
            {
                return false;
            }
            var isActionComplected = false;
            ManualResetEvent manualResetEvent=new ManualResetEvent(false);
            Thread thread = new Thread(() =>
            {
                action();
                manualResetEvent.Set();
                isActionComplected = true;
            });
            thread.Start();
            manualResetEvent.WaitOne(timeSpan);
            if (thread.IsAlive)
            {
                thread.Abort();//如果执行超时则回收线程
            }
            return isActionComplected;
        }
    }
}
