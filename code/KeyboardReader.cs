using System;
using System.Collections.Generic;

namespace EffectiveCSharpSamples.EventInvoke
{    
    internal class KeyPressArgs
    {
        internal char Key { get; }
        internal bool IsCtrl { get; }
        internal bool IsAlt { get; }

        internal KeyPressArgs(char key, bool isCtrl, bool isAlt)
        {
            Key = key;
            IsCtrl = isCtrl;
            IsAlt = isAlt;
        }
    }

    internal class KeyboardReader
    {
        public event EventHandler<KeyPressArgs> OnKeyPress;

        public IList<char> AllKeys => new List<char>();

        internal void ReadKeys(char exit)
        {
            var done = false;
            do
            {
                var nextKey = Console.ReadKey(true);
                OnKeyPress?.Invoke(this, new KeyPressArgs(nextKey.KeyChar,
                    ((nextKey.Modifiers & ConsoleModifiers.Control) != 0),
                    ((nextKey.Modifiers & ConsoleModifiers.Alt) != 0)));
                done = nextKey.KeyChar == exit;
                AllKeys.Add(nextKey.KeyChar);
            } while (!done);
        }
    }
}
