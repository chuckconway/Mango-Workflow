using System;

namespace MangoWorkFlow
{
    public static class WorkFlow
    {

        public static DoFlow Do(Action action)
        {
            action();
            return new DoFlow(true);
        }

        public static IfFlow If(Func<bool> eval)
        {
            if(eval())
            {
                return new IfFlow(true);
            }

            return new IfFlow(false);
        }

        public static DoIfFlow DoIf(Func<bool> eval, Action action)
        {
            if (eval())
            {
                action();
            }
            else
            {
                return new DoIfFlow(true, true);
            }

            return new DoIfFlow(false, false);
        }
    }
}
