﻿namespace BussinesSchool
{
    public interface IABMF : IID
    {
        void Modify();
        void Add();
        void Erase();
        string Find();
    }
}
