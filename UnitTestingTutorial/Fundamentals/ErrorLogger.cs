
using System;

namespace UnitTestingTutorial.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged;

        public void Log(string error)
        {
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();
                
            LastError = error; 
            
            // Write the log to a storage
            // ...

            OnErrorLog(Guid.NewGuid());
        }

        protected virtual void OnErrorLog(Guid errorId)
        {
            ErrorLogged?.Invoke(this, errorId);
        }
    }
}