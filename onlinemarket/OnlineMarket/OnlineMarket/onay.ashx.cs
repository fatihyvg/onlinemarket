using JsonServices;
using JsonServices.Web;

namespace OnlineMarket
{
    /// <summary>
    /// Summary description for onay
    /// </summary>
    public class onay : JsonHandler
    {

        public onay()
        {
            this.service.Name = "api";
            this.service.Description = "api tanımları";
            InterfaceConfiguration IConfig = new InterfaceConfiguration("RestFull", typeof(IServis), typeof(Servis));
            this.service.Interfaces.Add(IConfig);
            
        }
    }
}