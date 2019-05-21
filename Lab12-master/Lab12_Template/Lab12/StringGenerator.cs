﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Lab12
{
    class StringGenerator : IModel
    {

        IController controller;

        string get = string.Empty;
        string url = @"https://www.random.org/strings/?num=10&len=8&digits=on&upperalpha=on&loweralpha=on&unique=on&format=plain&rnd=new";


        public void getRequest()
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                get = reader.ReadToEnd();
            }
            notify();
        }

        public void notify()
        {
            Console.WriteLine(get);
        }

        public void setController(IController i)
        {
            controller =i;
        }
    }
}
