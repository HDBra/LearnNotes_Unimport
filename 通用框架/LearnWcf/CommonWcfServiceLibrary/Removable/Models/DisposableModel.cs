using System;

namespace CommonWcfServiceLibrary.Removable.Models
{
    public class DisposableModel:IDisposable
    {

        public DisposableModel()
        {
            Console.WriteLine();
        }

        public void Dispose()
        {
            Console.WriteLine();
        }
    }
}