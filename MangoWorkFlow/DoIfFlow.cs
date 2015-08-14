using System;

namespace MangoWorkFlow
{
    public class DoIfFlow
    {
        private readonly bool _isValid;
        private readonly bool _doElse;

        public DoIfFlow(bool isValid, bool doElse)
        {
            _isValid = isValid;
            _doElse = doElse;
        }

        public DoIfFlow DoIf(Func<bool> condition, Action action)
        {
            if (_isValid)
            {
                if (condition())
                {
                    action();
                }
                else
                {
                   return new DoIfFlow(_isValid, true);
                }
            }

            return new DoIfFlow(false, false);
        }

        public void DoElse(Action action)
        {
            if (_isValid && _doElse)
            {
                action();
            }
        }
    }
}
