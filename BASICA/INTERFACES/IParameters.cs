using System;

namespace BASICA
{
    public interface IParameters
    {
        void AddInt(string name, int value);
        void AddBit(string name, bool value);
        void AddFloat(string name, double value);
        void AddDateTime(string name, DateTime value);
        void AddVarchar(string name, int length, string value);
    }
}
