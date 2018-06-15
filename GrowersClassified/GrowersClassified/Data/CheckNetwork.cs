using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Connectivity;

namespace GrowersClassified.Data
{
    public class CheckNetwork
    {
        public static bool IsInternet()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                // There is an internet connection, so IsConnected = true
                return true;
            }
            else
            {
                // There is no internet connection, so IsConnected = false    
                return false;
            }
        }
    }
}