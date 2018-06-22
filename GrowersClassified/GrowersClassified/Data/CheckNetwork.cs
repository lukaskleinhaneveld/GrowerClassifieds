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
                // Return "true" if an internet connection is established
                return true;
            }
            else
            {
                // Return "false" if no internet connection is established   
                return false;
            }
        }
    }
}