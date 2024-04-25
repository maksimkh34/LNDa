using System;

namespace AtomicBackuper
{
    [Serializable]
    internal class InvalidDataProvidedException : Exception
    {
        public InvalidDataProvidedException() : base("Provided data contains delimeter. ") { }
    }
}
