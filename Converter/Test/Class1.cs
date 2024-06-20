using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    internal class Class1
    {
        public static void Test1<T>()
        {
            try
            {
                throw new HttpRequestException("Error in: ");
            }
            catch
            {
                throw new HttpRequestException($"Fejl i {typeof(T).Name}");
            }

        }

        public static void Test2()
        {
            try 
            {
                Test1<SubnetInfo>();   
            
            }
            catch(HttpRequestException e)
            {
                Debug.WriteLine(e.Message);
            }

        }

        

    }
}
