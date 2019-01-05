using System;
using System.Collections.Generic;
using System.Text;

namespace GrowersClassified.Data
{
    public interface IFtpWebRequest
    {
        string upload(string FtpUrl, string fileName, string userName, string password, string UploadDirectory = "");
    }
}
