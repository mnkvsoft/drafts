AutoResetEvent pingWaitHandle = new AutoResetEvent(true);
AutoResetEvent pongWaitHandle = new AutoResetEvent(false);

var t1 = StartThread("---- ping", pingWaitHandle, pongWaitHandle);
var t2 = StartThread("------------- pong", pongWaitHandle, pingWaitHandle);

t1.Join();
t2.Join();

Thread StartThread(string text, AutoResetEvent wait, AutoResetEvent set)
{
    Thread t = new Thread(() =>
    {
        for (int i = 0; i < 20; i++)
        {
            wait.WaitOne();
            Console.WriteLine(text);
            set.Set();
        }
    });
    t.Start();
    return t;
}