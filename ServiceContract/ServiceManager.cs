using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Xml;
using System.ServiceModel.Channels;

namespace ServiceContract
{
  public class ServiceManager
  {
    public static ISampleService CreateChannel(string address_suffix)
    {


      Binding binding = CreateBinding();
      string address = GetAddress() + address_suffix;
      Helpers.WriteLine(String.Format("Starting service at endpoint {0}", address), ConsoleColor.Cyan);

      var factory = new ChannelFactory<ISampleService>(binding);
      //factory.Endpoint.Contract.SessionMode = SessionMode.Allowed;
      EndpointAddress ep = new EndpointAddress(address);
      return factory.CreateChannel(ep);
    }

    public static void OpenHost(ServiceHost hostDefault, string address_suffix)
    {
      Binding binding = CreateBinding();
      string address = GetAddress() + address_suffix;

      hostDefault.AddServiceEndpoint(
        typeof(ISampleService),
        binding,
        address);
      hostDefault.Open();
    }

    private static NetTcpBinding CreateBinding()
    {
      NetTcpBinding binding = new NetTcpBinding();
      //binding.PortSharingEnabled = true;
      //portsharingBinding.ReliableSession.Enabled = true;
      //portsharingBinding.ReliableSession.Ordered = false;
      binding.MaxReceivedMessageSize = 1000000;

      XmlDictionaryReaderQuotas myReaderQuotas = new XmlDictionaryReaderQuotas();
      myReaderQuotas.MaxStringContentLength = 10000;
      myReaderQuotas.MaxArrayLength = 10000;
      myReaderQuotas.MaxBytesPerRead = 10000;
      myReaderQuotas.MaxDepth = 10000;
      myReaderQuotas.MaxNameTableCharCount = 10000;

      binding.GetType().GetProperty("ReaderQuotas").SetValue(binding, myReaderQuotas, null);
      return binding;
    }

    public static string GetAddress()
    {
      return "net.tcp://localhost:3456/sample";
    }
  }
}
