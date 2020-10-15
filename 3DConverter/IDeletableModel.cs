using System;

namespace _3DConverter
{
    public interface IDeletableModel
    {
        event Action FileDeleted;

        void DeleteFile();
    }
}