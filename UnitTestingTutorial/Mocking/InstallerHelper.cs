﻿using System.Net;

namespace UnitTestingTutorial.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private readonly IFileDownloader _fileDownloader;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }
        
        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _fileDownloader.DownloadFile(
                    $"http://example.com/{customerName}/{installerName}",
                    _setupDestinationFile);
                
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}