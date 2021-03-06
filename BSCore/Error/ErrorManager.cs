﻿namespace BSCore.Error
{
    public class ErrorManager
    {
        public CoreManager CoreManager { get; set; }
        /// <summary>
        /// Instantiate a new ErrorManager
        /// </summary>
        /// <param name="manager">The parent CoreManager</param>
        public ErrorManager(CoreManager manager)
        {
            CoreManager = manager;
        }

        private void HandleError(Error error)
        {
            // Do something with error
        }
    }
}
