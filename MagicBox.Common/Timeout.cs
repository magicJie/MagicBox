using System;
using System.Threading;

namespace MagicBox.Common
{
    /// <summary>
    /// 提供了方法调度的超时管理
    /// </summary>
    public class Timeout
    {
        private readonly ManualResetEvent _timeoutObject;
        private bool _isTimeout;
        //标记变量
        public Action Action;

        public Timeout()
        {
            //初始状态为停止
            _timeoutObject=new ManualResetEvent(true);
        }

        /// <summary>
        /// 指定超时时间 异步执行某个方法
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns>超时为true，否则为false</returns>
        public bool DoWithTimeout(TimeSpan timeSpan)
        {
            if (Action==null)
            {
                return false;
            }
            _timeoutObject.Reset();
            _isTimeout = true;
            Action.BeginInvoke(DoAsyncCallBack, null);
            //等待信号 set
            if (!_timeoutObject.WaitOne(timeSpan,false))
            {
                _isTimeout = true;
            }
            return _isTimeout;
        }
        /// <summary>
        /// 异步委托 回调方法
        /// </summary>
        /// <param name="result"></param>
        private void DoAsyncCallBack(IAsyncResult result)
        {
            try
            {
                Action.EndInvoke(result);
                _isTimeout = false;
            }
            catch (Exception)
            {
                _isTimeout = true;
            }
            finally
            {
                _timeoutObject.Set();
            }
        }
    }
}
