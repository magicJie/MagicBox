using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace MagicBox.Common
{
    public class Logger : IDisposable
    {
        private static Logger _instance;
        private bool _state;
        private static readonly string LogPath = AppDomain.CurrentDomain.BaseDirectory + "\\AppData\\Log\\";
        private readonly string _currentLogFile;
        private readonly object _lock;
        private readonly Semaphore _semaphore;
        private readonly Queue<string> _logCache;
        private StreamWriter _writer;

        static Logger()
        {
            _instance = new Logger();
        }

        public static Logger Instance
        {
            get { return _instance; }
        }

        private Logger()
        {
            if (!Directory.Exists(LogPath)) Directory.CreateDirectory(LogPath);
            _currentLogFile = LogPath + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
           // if (!File.Exists(_currentLogFile)) File.CreateText(_currentLogFile);
            _lock = new object();
            _semaphore = new Semaphore(0, 1000);//限制最多1000个线程同时访问
            _state = true;
            //初始化logger实例时启动写文本的线程
            _logCache = new Queue<string>();
            var thread = new Thread(Work) { IsBackground = true };
            thread.Name = "写日志线程";
            thread.Start();
        }

        private void Work()
        {
            while (true)
            {
                if (_logCache != null && _logCache.Count > 0)
                {
                    string log = null;
                    lock (_lock)
                    {
                        if (_logCache.Count > 0) log = _logCache.Dequeue();
                    }
                    if (log != null)
                    {
                        if (_writer == null)
                        {
                            _writer = new StreamWriter(_currentLogFile, true, Encoding.UTF8);
                        }
                        if (!log.EndsWith("\r\n")) log += "\r\n";
                        _writer.Write(log);
                        _writer.Flush();
                    }
                }
                else
                    if (WaitLog()) break;
            }
        }

        private bool WaitLog()
        {
            if (_state)
            {
                //WaitHandle.WaitAny(new WaitHandle[] { _semaphore }, -1, false);//指定等待
                _semaphore.WaitOne();
                return false;
            }
            if (_writer != null)
            {
                _writer.Flush();
                _writer.Close();
                _writer.Dispose();
                _writer = null;
            }
            return true;
        }

        public void Write(string log)
        {
            if (_logCache != null)
            {
                lock (_lock)
                {
                    _logCache.Enqueue(log);
                    _semaphore.Release();
                }
            }
        }

        public void Dispose()
        {
            _state = false;
        }
    }
}
